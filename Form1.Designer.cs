namespace TetrisChallenge
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnPlay = new Button();
            imageList_btnPlay = new ImageList(components);
            lblPlayPause = new Label();
            lblNextPiece = new Label();
            label1 = new Label();
            lblUserName = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(493, 819);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(532, 279);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(229, 178);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Transparent;
            btnPlay.Cursor = Cursors.Hand;
            btnPlay.FlatStyle = FlatStyle.Popup;
            btnPlay.ForeColor = Color.Transparent;
            btnPlay.ImageList = imageList_btnPlay;
            btnPlay.Location = new Point(514, 32);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 74);
            btnPlay.TabIndex = 2;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // imageList_btnPlay
            // 
            imageList_btnPlay.ColorDepth = ColorDepth.Depth8Bit;
            imageList_btnPlay.ImageStream = (ImageListStreamer)resources.GetObject("imageList_btnPlay.ImageStream");
            imageList_btnPlay.TransparentColor = Color.Transparent;
            imageList_btnPlay.Images.SetKeyName(0, "botao-play.png");
            imageList_btnPlay.Images.SetKeyName(1, "botao-pausa.png");
            // 
            // lblPlayPause
            // 
            lblPlayPause.AutoSize = true;
            lblPlayPause.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlayPause.Location = new Point(514, 9);
            lblPlayPause.Name = "lblPlayPause";
            lblPlayPause.Size = new Size(79, 20);
            lblPlayPause.TabIndex = 3;
            lblPlayPause.Text = "Play/Pause";
            // 
            // lblNextPiece
            // 
            lblNextPiece.AutoSize = true;
            lblNextPiece.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNextPiece.Location = new Point(532, 256);
            lblNextPiece.Name = "lblNextPiece";
            lblNextPiece.Size = new Size(99, 20);
            lblNextPiece.TabIndex = 3;
            lblNextPiece.Text = "Próxima peça";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(682, 32);
            label1.Name = "label1";
            label1.Size = new Size(71, 30);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserName.Location = new Point(532, 460);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(99, 20);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "Próxima peça";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 843);
            Controls.Add(label1);
            Controls.Add(lblUserName);
            Controls.Add(lblNextPiece);
            Controls.Add(lblPlayPause);
            Controls.Add(btnPlay);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnPlay;
        private ImageList imageList_btnPlay;
        private Label lblPlayPause;
        private Label lblNextPiece;
        private Label label1;
        private Label lblUserName;
    }
}