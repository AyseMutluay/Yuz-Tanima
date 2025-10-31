namespace YuzTanimaProjesi
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
            picCapture = new PictureBox();
            btnStart = new Button();
            txtName = new TextBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)picCapture).BeginInit();
            SuspendLayout();
            // 
            // picCapture
            // 
            picCapture.Location = new Point(12, 25);
            picCapture.Name = "picCapture";
            picCapture.Size = new Size(486, 392);
            picCapture.SizeMode = PictureBoxSizeMode.StretchImage;
            picCapture.TabIndex = 0;
            picCapture.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(543, 41);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(210, 40);
            btnStart.TabIndex = 1;
            btnStart.Text = "Kamerayı Başlat";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(543, 114);
            txtName.Name = "txtName";
            txtName.Size = new Size(210, 27);
            txtName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(543, 170);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(210, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Yüz Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(txtName);
            Controls.Add(btnStart);
            Controls.Add(picCapture);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picCapture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picCapture;
        private Button btnStart;
        private TextBox txtName;
        private Button btnSave;
    }
}
