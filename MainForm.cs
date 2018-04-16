using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using ImageEncryptCompress;
namespace ImageQuantization
{
    public partial class MainForm : Form
    {
        RGBPixel[,] ImageMatrix;
        string OpenedFilePath;
        public BinaryFormatter formatter = new BinaryFormatter();
        

    
        public MainForm()
        {
            InitializeComponent();
        }
        string FilePath = "";
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
                txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
                txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
                FilePath = OpenedFilePath.Remove((OpenedFilePath.Length - 4), 4);
                //img = new Bitmap(pictureBox1.Image);
                img = new Bitmap(OpenedFilePath);
            }
        }
        Bitmap img ;

        private void Compression_Click(object sender, EventArgs e)
        {
            Compression.Enabled = false;
            Huffman_Tree tree = new Huffman_Tree(img);
            tree.BuildTree();
            List<bool> st = new List<bool>();
            tree.Encode(tree.Rroot, st, 'R');
            st = new List<bool>();
            tree.Encode(tree.Groot, st, 'G');
            st = new List<bool>();
            tree.Encode(tree.Broot, st, 'B');
            CompressionOutput(tree, FilePath);
            tree.Compress(img, FilePath);
            FileStream fs = new FileStream(FilePath + ".dat", FileMode.Create, FileAccess.Write);
            tree.FrequencyList[0].Item1.Add(-102, UInt32.Parse(TAP.Text));
            tree.FrequencyList[0].Item1.Add(-103, UInt32.Parse(SEED.Text));
            formatter.Serialize(fs, tree.FrequencyList);
            fs.Close();
            Compression.Enabled = true;
            MessageBox.Show("Compressed Image has been Saved.", "Compression Sucessful", MessageBoxButtons.OK);

        }
        private void Decompress_Click(object sender, EventArgs e)
        {
            Decompress.Enabled = false;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Data files (*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog1.FileName.Remove((openFileDialog1.FileName.Length - 4), 4);
                FileStream rs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                Huffman_Tree tree = new Huffman_Tree();
                tree.FrequencyList=(List<Tuple<Dictionary<int, uint>, BitArray>>)formatter.Deserialize(rs);
                tree.BuildTree();
                List<bool> st = new List<bool>();
                tree.Encode(tree.Rroot, st, 'R');
                st = new List<bool>();
                tree.Encode(tree.Groot, st, 'G');
                st = new List<bool>();
                tree.Encode(tree.Broot, st, 'B');
                img = tree.Decompress();
                pictureBox2.Image = img;
                txtWidth.Text = tree.FrequencyList[0].Item1[-100].ToString();
                txtHeight.Text = tree.FrequencyList[0].Item1[-101].ToString();
                TAP.Text= tree.FrequencyList[0].Item1[-102].ToString();
                SEED.Text= tree.FrequencyList[0].Item1[-103].ToString();
                rs.Close();
                img.Save(FilePath + "new.bmp");
                MessageBox.Show("Decompressed Image has been Saved.", "Decompression Sucessful", MessageBoxButtons.OK);
            }
                Decompress.Enabled = true;

        }
        private void CompressionOutput(Huffman_Tree tree, string path)
        {
            long TotalBR = 0, TotalBG = 0, TotalBB = 0;
            StreamWriter sw = new StreamWriter(path + ".txt");
            sw.Write("Color\tFrequency\t\tHuffmanCode\t\t\t\tTotal Bits\n-Red-\n");
            foreach (var x in tree.RedCodeTable)
            {
                sw.Write(x.Key + "\t\t\t" + tree.RFrequencies[x.Key] + "\t\t\t");
                foreach (var i in x.Value)
                {
                    if (i == false)
                        sw.Write(0);
                    else
                        sw.Write(1);
                }
                sw.Write("\t\t\t\t" + tree.RFrequencies[x.Key] * x.Value.Count + "\n");
                TotalBR += tree.RFrequencies[x.Key] * x.Value.Count;
            }
            sw.Write("\nTotal Bits = " + TotalBR + "\n-------------------------------------------------------------------------------------------------------------\n");
            sw.Write("Color\tFrequency\t\tHuffmanCode\t\t\t\tTotal Bits\n-Green-\n");
            foreach (var x in tree.GreenCodeTable)
            {
                sw.Write(x.Key + "\t\t\t" + tree.GFrequencies[x.Key] + "\t\t\t");
                foreach (var i in x.Value)
                {
                    if (i == false)
                        sw.Write(0);
                    else
                        sw.Write(1);
                }
                sw.Write("\t\t\t\t" + tree.GFrequencies[x.Key] * x.Value.Count + "\n");
                TotalBG += tree.GFrequencies[x.Key] * x.Value.Count;
            }
            sw.Write("\nTotal Bits = " + TotalBG + "\n-------------------------------------------------------------------------------------------------------------\n");
            sw.Write("Color\tFrequency\t\tHuffmanCode\t\t\t\tTotal Bits\n-Blue-\n");
            foreach (var x in tree.BlueCodeTable)
            {
                sw.Write(x.Key + "\t\t\t" + tree.BFrequencies[x.Key] + "\t\t\t");
                foreach (var i in x.Value)
                {
                    if (i == false)
                        sw.Write(0);
                    else
                        sw.Write(1);
                }
                sw.Write("\t\t\t\t" + tree.BFrequencies[x.Key] * x.Value.Count + "\n");
                TotalBB += tree.BFrequencies[x.Key] * x.Value.Count;

            }
            sw.Write("\nTotal Bits = " + TotalBB + "\n-------------------------------------------------------------------------------------------------------------\n");
            sw.Write("Compression Output\n" + (double)(TotalBR + TotalBG + TotalBB) / 8 + "Bytes");
            sw.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encrypt.Enabled = false;
            //img = new Bitmap(pictureBox1.Image);
            EncDec(SEED.Text, Int32.Parse(TAP.Text));
            img.Save(FilePath + "Encyrpted.bmp");
            pictureBox2.Image = img;
            MessageBox.Show("Encyrpted Image has been Saved.", "Encryption Sucessful", MessageBoxButtons.OK);
            Encrypt.Enabled = true;
        }
        private void Decrypt_Click(object sender, EventArgs e)
        {
            Decrypt.Enabled = false;
           // img = new Bitmap(pictureBox2.Image);
           
            EncDec(SEED.Text, Int32.Parse(TAP.Text));
            Decrypt.Enabled = true;
            img.Save(FilePath + "new.bmp");
            pictureBox1.Image = img;
            MessageBox.Show("Decyrpted Image has been Saved.", "Decyrption Sucessful", MessageBoxButtons.OK);
        }

        //This function Encrypt or Decrypt the image
        //O(N^2)
        public bool EncDec(string seed, int tap)
        {
            LFSR lf = new LFSR(seed, tap);
            int R, G, B, oldBlue, oldGreen, oldRed;
            unsafe
            {
                // locking the bits in order to start making operations on them
                BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, img.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(img.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* ptrFirstPixel = (byte*)bitmapData.Scan0;
                

                for (int y = 0; y < heightInPixels; y++)
                {
                    byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride); // A pointer that points on each line
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        //Generate 8bits for each color
                        R = (int)lf.Kstep(8);
                        G = (int)lf.Kstep(8);
                        B = (int)lf.Kstep(8);
                        oldBlue = currentLine[x];
                         oldGreen = currentLine[x + 1];
                         oldRed = currentLine[x + 2];

                        // Generate and set the new pixel value
                        currentLine[x] = (byte)(oldBlue ^ B);
                        currentLine[x + 1] = (byte)(oldGreen ^ G);
                        currentLine[x + 2] = (byte)(oldRed ^ R);
                    }
                }
                //Unlocking the bits
                img.UnlockBits(bitmapData);
            }
            return true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}