using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageEncryptCompress
{
    public class LFSR
    {
        public long seed;
        private long andnbits,  checktapbit, newbit, outbit, rett=0, bk;
        public int tap, NBits;
        public Dictionary<long, long> mem;

        public LFSR(string sseed, int tap) { this.seed = Convert.ToInt64(sseed, 2); this.tap = Math.Min( tap,sseed.Length);mem = new Dictionary<long, long>(); this.NBits = sseed.Length;  andnbits = (long)(Math.Pow(2, NBits)) - 1;  }

        public long Onestep() //Make a one lfsr step
        {

            checktapbit = 1 << this.tap; 
            newbit = (checktapbit & seed) >> this.tap;  //tap bit
            outbit = seed >> NBits - 1;    //most significant bit
            newbit = newbit ^ outbit;     //gets new bit that will be xored with the least significant bit 0 or 1
            seed = (seed << 1);           //Shift left
            seed = seed ^ newbit;         // Putting the new generated bit
           seed = seed & andnbits;       //Making sure that the number doesn't exceed the bits length 

            return seed & 1;


        }
        public long Kstep(int K) //Extract Kbit new generated integer
        {
            rett = 0;
            if(NBits<8)
            {
                for (int i = 0; i < K; i++)
                {
                    bk = this.Onestep();
                    rett = rett | bk;
                    rett = rett << 1;
                }
                rett = rett >> 1;

                return rett;

            }
            else
            {


                long newseedd;
                if ((mem.Count < 100) && mem.TryGetValue(seed, out newseedd))
                {
                    seed = newseedd;
                }
                else
                {

                    long oldseed = seed;

                    for (int i = 0; i < K; i++)
                    {
                        this.Onestep();
                    }

                    if (mem.Count < 100)
                        mem.Add(oldseed, seed);
                }



                return seed & 255;
            }
            
                
        }
    }
}
