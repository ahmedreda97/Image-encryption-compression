using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageEncryptCompress;
using System.Drawing;
namespace ImageQuantization
{
    static public class Program
    {
       

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}