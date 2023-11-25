namespace TetrisChallenge
{
    partial class FormEntrada
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
            button1 = new Button();
            label1 = new Label();
            txtUsername = new TextBox();
            label2 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(230, 229);
            button1.Name = "button1";
            button1.Size = new Size(80, 43);
            button1.TabIndex = 0;
            button1.Text = "Jogar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 186);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome do jogador:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(221, 183);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(169, 23);
            txtUsername.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(448, 21);
            label2.TabIndex = 1;
            label2.Text = "*LAYOUT DA TELA INICIAL E JOGO AINDA A SEREM FEITOS";
            // 
            // button2
            // 
            button2.Location = new Point(310, 229);
            button2.Name = "button2";
            button2.Size = new Size(80, 43);
            button2.TabIndex = 0;
            button2.Text = "Ranking";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormEntrada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 363);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormEntrada";
            Text = "FormEntrada";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private Button button2;
    }
}