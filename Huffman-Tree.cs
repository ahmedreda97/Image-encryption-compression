using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Drawing.Imaging;

namespace ImageQuantization
{
    [Serializable]
    class Huffman_Tree
    {
        public List<Tuple<Dictionary<int, uint>,BitArray>> FrequencyList = new List<Tuple<Dictionary<int, uint>, BitArray>>();

        public Node Rroot;
        public Node Groot;
        public Node Broot;

        public Dictionary<int, uint> RFrequencies = new Dictionary<int, uint>();
        public Dictionary<int, uint> GFrequencies = new Dictionary<int, uint>();
        public Dictionary<int, uint> BFrequencies = new Dictionary<int, uint>();

        PriorityQueue<uint, Node> RedNodes = new PriorityQueue<uint, Node>();
        PriorityQueue<uint, Node> GreenNodes = new PriorityQueue<uint, Node>();
        PriorityQueue<uint, Node> BlueNodes = new PriorityQueue<uint, Node>();

        public SortedDictionary<int, List<bool>> RedCodeTable = new SortedDictionary<int, List<bool>>();
        public SortedDictionary<int, List<bool>> GreenCodeTable = new SortedDictionary<int, List<bool>>();
        public SortedDictionary<int, List<bool>> BlueCodeTable = new SortedDictionary<int, List<bool>>();

        Queue<bool> RedCode = new Queue<bool>();
        Queue<bool> GreenCode = new Queue<bool>();
        Queue<bool> BlueCode = new Queue<bool>();

        BitArray RC;
        BitArray BC;
        BitArray GC;

        uint Width, Height;

        public Huffman_Tree()
        {

        }
        public Huffman_Tree(Bitmap img)
        {

            Width = (uint)img.Width;
            Height = (uint)img.Height;
            RFrequencies.Add(-100, Width);
            RFrequencies.Add(-101, Height);
            unsafe
            {
                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(img.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        if (!RFrequencies.ContainsKey(currentLine[x+2]))
                            RFrequencies.Add(currentLine[x + 2], 0);
                        if (!GFrequencies.ContainsKey(currentLine[x + 1]))
                            GFrequencies.Add(currentLine[x + 1], 0);
                        if (!BFrequencies.ContainsKey(currentLine[x]))
                            BFrequencies.Add(currentLine[x], 0);

                        RFrequencies[currentLine[x + 2]]++;
                        GFrequencies[currentLine[x + 1]]++;
                        BFrequencies[currentLine[x]]++;
                    }
                }
                img.UnlockBits(bitmapData);
            }
            FrequencyList.Add(new Tuple<Dictionary<int, uint>, BitArray>(RFrequencies, RC));
            FrequencyList.Add(new Tuple<Dictionary<int, uint>, BitArray>(GFrequencies, GC));
            FrequencyList.Add(new Tuple<Dictionary<int, uint>, BitArray>(BFrequencies, BC));
        }
        public void BuildTree()
        {
            Node parent;
            Node node;
            foreach (var frequency in FrequencyList[0].Item1)
            {
                if (frequency.Key == -100)
                    Width = frequency.Value;
                else if (frequency.Key == -101)
                    Height = frequency.Value;
                else if(frequency.Key>-1)
                {
                    node = new Node(frequency.Key, frequency.Value);
                    RedNodes.Enqueue(frequency.Value, node);
                }
            }
            while (RedNodes.Count > 1)
            {
                parent = new Node(RedNodes.Dequeue().Value, RedNodes.Dequeue().Value);
                RedNodes.Enqueue(parent.Value, parent);
                Rroot = parent;
            }

            foreach (var frequency in FrequencyList[1].Item1)
            {
                node = new Node(frequency.Key, frequency.Value);
                GreenNodes.Enqueue(frequency.Value, node);
            }
            while (GreenNodes.Count > 1)
            {
                parent = new Node(GreenNodes.Dequeue().Value, GreenNodes.Dequeue().Value);
                GreenNodes.Enqueue(parent.Value, parent);
                Groot = parent;
            }

            foreach (var frequency in FrequencyList[2].Item1)
            {
                node = new Node(frequency.Key, frequency.Value);
                BlueNodes.Enqueue(frequency.Value, node);
            }
            while (BlueNodes.Count > 1)
            {
                parent = new Node(BlueNodes.Dequeue().Value, BlueNodes.Dequeue().Value);
                BlueNodes.Enqueue(parent.Value, parent);
                Broot = parent;
            }
            
        }
        public void Encode(Node N, List<bool> code, char color)
        {
            if (color == 'R')
            {
                if (N.Left == null && N.Right == null)
                {
                    RedCodeTable[N.Color] = new List<bool>(code);
                    return;
                }
                code.Add(true);
                Encode(N.Left, code, 'R');
                code.RemoveAt(code.Count - 1);
                code.Add(false);
                Encode(N.Right, code, 'R');
                code.RemoveAt(code.Count - 1);
            }
            else if (color == 'G')
            {
                if (N.Left == null && N.Right == null)
                {
                    GreenCodeTable[N.Color] = new List<bool>(code);
                    return;
                }
                code.Add(true);
                Encode(N.Left, code, 'G');
                code.RemoveAt(code.Count - 1);
                code.Add(false);
                Encode(N.Right, code, 'G');
                code.RemoveAt(code.Count - 1);
            }
            else
            {
                if (N.Left == null && N.Right == null)
                {
                    BlueCodeTable[N.Color] = new List<bool>(code);
                    return;
                }
                code.Add(true);
                Encode(N.Left, code, 'B');
                code.RemoveAt(code.Count - 1);
                code.Add(false);
                Encode(N.Right, code, 'B');
                code.RemoveAt(code.Count - 1);
            }
        }
        public void Compress(Bitmap img, string name)
        {
            unsafe
            {
                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(img.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        foreach (bool c in BlueCodeTable[currentLine[x]])
                        {
                            BlueCode.Enqueue(c);
                        }
                        foreach (bool c in GreenCodeTable[currentLine[x+1]])
                        {
                            GreenCode.Enqueue(c);
                        }
                        foreach (bool c in RedCodeTable[currentLine[x+2]])
                        {
                            RedCode.Enqueue(c);
                        }
                    }
                }
                img.UnlockBits(bitmapData);
            }
            RC = new BitArray(RedCode.ToArray());
            GC = new BitArray(GreenCode.ToArray());
            BC = new BitArray(BlueCode.ToArray());
            FrequencyList.RemoveAt(0);
            FrequencyList.RemoveAt(0);
            FrequencyList.RemoveAt(0);
            FrequencyList.Add(new Tuple<Dictionary<int, uint>, BitArray>(RFrequencies, RC));
            FrequencyList.Add(new Tuple<Dictionary<int, uint>, BitArray>(GFrequencies, GC));
            FrequencyList.Add(new Tuple<Dictionary<int, uint>, BitArray>(BFrequencies, BC));
        }
        public Bitmap Decompress()
        {
            Bitmap img = new Bitmap((int)Width, (int)Height);
            Node Root = Rroot;
            Queue<int> Red = new Queue<int>();
            for(int i=0;i<FrequencyList[0].Item2.Count;i++)
            {
                if (FrequencyList[0].Item2.Get(i) == true)
                {
                    Root = Root.Left;
                }
                else
                {
                    Root = Root.Right;
                }
                if (Root.Left == null && Root.Right == null)
                {
                    Red.Enqueue(Root.Color);
                    Root = Rroot;
                }
            }
            Root = Groot;
            Queue<int> Green = new Queue<int>();
            for (int i = 0; i < FrequencyList[1].Item2.Count; i++)
            {
                if (FrequencyList[1].Item2.Get(i) == true)
                {
                    Root = Root.Left;
                }
                else
                {
                    Root = Root.Right;
                }
                if (Root.Left == null && Root.Right == null)
                {
                    Green.Enqueue(Root.Color);
                    Root = Groot;
                }
            }
            Root = Broot;
            Queue<int> Blue = new Queue<int>();
            for (int i = 0; i < FrequencyList[2].Item2.Count; i++)
            {
                if (FrequencyList[2].Item2.Get(i) == true)
                {
                    Root = Root.Left;
                }
                else
                {
                    Root = Root.Right;
                }
                if (Root.Left == null && Root.Right == null)
                {
                    Blue.Enqueue(Root.Color);
                    Root = Broot;
                }
            }
            
                    unsafe
                    {
                        BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);
                        int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(img.PixelFormat) / 8;
                        int heightInPixels = bitmapData.Height;
                        int widthInBytes = bitmapData.Width * bytesPerPixel;
                        byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

                        for (int y = 0; y < heightInPixels; y++)
                        {
                            byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                            for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                            {


                                // calculate new pixel value
                                currentLine[x] = (byte)Blue.Dequeue();
                                currentLine[x + 1] = (byte)Green.Dequeue();
                                currentLine[x + 2] = (byte)Red.Dequeue();
                        currentLine[x + 3] = 255;
                    }
                        }
                        img.UnlockBits(bitmapData);
            }
            return img;
        }
    }
 
}
