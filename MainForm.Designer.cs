namespace ImageQuantization
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Compression = new System.Windows.Forms.Button();
            this.Decompress = new System.Windows.Forms.Button();
            this.Encrypt = new System.Windows.Forms.Button();
            this.SEED = new System.Windows.Forms.TextBox();
            this.TAP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Decrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(412, 360);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(589, 479);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(126, 89);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 475);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original Image";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(491, 540);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(75, 27);
            this.txtHeight.TabIndex = 8;
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(491, 493);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(75, 27);
            this.txtWidth.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(417, 496);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(417, 543);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Height";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 456);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.panel2.Location = new System.Drawing.Point(628, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 456);
            this.panel2.TabIndex = 16;
            // 
            // Compression
            // 
            this.Compression.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Compression.Location = new System.Drawing.Point(995, 479);
            this.Compression.Name = "Compression";
            this.Compression.Size = new System.Drawing.Size(147, 54);
            this.Compression.TabIndex = 17;
            this.Compression.Text = "Compress";
            this.Compression.UseVisualStyleBackColor = true;
            this.Compression.Click += new System.EventHandler(this.Compression_Click);
            // 
            // Decompress
            // 
            this.Decompress.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Decompress.Location = new System.Drawing.Point(994, 539);
            this.Decompress.Name = "Decompress";
            this.Decompress.Size = new System.Drawing.Size(148, 51);
            this.Decompress.TabIndex = 18;
            this.Decompress.Text = "Decompress";
            this.Decompress.UseVisualStyleBackColor = true;
            this.Decompress.Click += new System.EventHandler(this.Decompress_Click);
            // 
            // Encrypt
            // 
            this.Encrypt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Encrypt.Location = new System.Drawing.Point(245, 519);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(117, 42);
            this.Encrypt.TabIndex = 19;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.button1_Click);
            // 
            // SEED
            // 
            this.SEED.Location = new System.Drawing.Point(114, 539);
            this.SEED.Name = "SEED";
            this.SEED.Size = new System.Drawing.Size(100, 22);
            this.SEED.TabIndex = 21;
            // 
            // TAP
            // 
            this.TAP.Location = new System.Drawing.Point(114, 567);
            this.TAP.Name = "TAP";
            this.TAP.Size = new System.Drawing.Size(100, 22);
            this.TAP.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 544);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Seed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 572);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tap position";
            // 
            // Decrypt
            // 
            this.Decrypt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Decrypt.Location = new System.Drawing.Point(245, 565);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(117, 37);
            this.Decrypt.TabIndex = 25;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(779, 475);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Encyrpted Image";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 690);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Decrypt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TAP);
            this.Controls.Add(this.SEED);
            this.Controls.Add(this.Encrypt);
            this.Controls.Add(this.Decompress);
            this.Controls.Add(this.Compression);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Image Enctryption and Compression...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Compression;
        private System.Windows.Forms.Button Decompress;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.TextBox SEED;
        private System.Windows.Forms.TextBox TAP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Label label2;
    }
}

