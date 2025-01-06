namespace youtube_to_mp3_v3
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(28, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 259);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(240, 23);
            label1.Name = "label1";
            label1.Size = new Size(198, 28);
            label1.TabIndex = 1;
            label1.Text = "Please follow the steps";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins", 9.75F, FontStyle.Italic);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(453, 66);
            label2.Name = "label2";
            label2.Size = new Size(176, 46);
            label2.TabIndex = 2;
            label2.Text = "1. Paste link (you can also\r\ninput multiple links)";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins", 9.75F, FontStyle.Italic);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(453, 128);
            label3.Name = "label3";
            label3.Size = new Size(185, 46);
            label3.TabIndex = 3;
            label3.Text = "2. Select where to save the\r\ndownloaded music.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins", 9.75F, FontStyle.Italic);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(453, 192);
            label4.Name = "label4";
            label4.Size = new Size(162, 46);
            label4.TabIndex = 4;
            label4.Text = "3. This will download all\r\nthe links you provided.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins", 9.75F, FontStyle.Italic);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(453, 257);
            label5.Name = "label5";
            label5.Size = new Size(154, 69);
            label5.TabIndex = 5;
            label5.Text = "4. [Optional] - This will\r\nonly check if there's a \r\nduplicate link.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Poppins", 9.75F, FontStyle.Italic);
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(144, 344);
            label6.Name = "label6";
            label6.Size = new Size(356, 23);
            label6.TabIndex = 6;
            label6.Text = "Note: Always to press [Enter] when putting a new link\r\n";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(668, 395);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form2";
            ShowIcon = false;
            Text = "Steps";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}