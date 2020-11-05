namespace ImageProccessing_HW1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.loadBtn = new System.Windows.Forms.Button();
            this.preImgBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.afterImgBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.preImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(196, 503);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(100, 29);
            this.loadBtn.TabIndex = 0;
            this.loadBtn.Text = "Load Image";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // preImgBox
            // 
            this.preImgBox.Location = new System.Drawing.Point(13, 1);
            this.preImgBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.preImgBox.Name = "preImgBox";
            this.preImgBox.Size = new System.Drawing.Size(531, 475);
            this.preImgBox.TabIndex = 1;
            this.preImgBox.TabStop = false;
            this.preImgBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(778, 503);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save Image";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // afterImgBox
            // 
            this.afterImgBox.Location = new System.Drawing.Point(551, 1);
            this.afterImgBox.Name = "afterImgBox";
            this.afterImgBox.Size = new System.Drawing.Size(504, 475);
            this.afterImgBox.TabIndex = 3;
            this.afterImgBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.afterImgBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.preImgBox);
            this.Controls.Add(this.loadBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.preImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterImgBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.PictureBox preImgBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox afterImgBox;
    }
}

