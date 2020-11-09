﻿namespace ImageProccessing_HW1
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
            this.actionList = new System.Windows.Forms.ListBox();
            this.subactionList = new System.Windows.Forms.ListBox();
            this.thresholdMinInputBox = new System.Windows.Forms.TextBox();
            this.thresholdMaxInputBox = new System.Windows.Forms.TextBox();
            this.doThreshold = new System.Windows.Forms.Button();
            this.undoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.preImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(41, 493);
            this.loadBtn.Margin = new System.Windows.Forms.Padding(4);
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
            this.preImgBox.Margin = new System.Windows.Forms.Padding(4);
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
            // actionList
            // 
            this.actionList.FormattingEnabled = true;
            this.actionList.ItemHeight = 15;
            this.actionList.Items.AddRange(new object[] {
            "1. RGB Extraction & Transformation",
            "2. Smooth filter",
            "3. Histogram Equalization",
            "4. User-defined thresholding",
            "5. Sobel edge detection",
            "6. Threshold of (5)",
            "7. Image registration"});
            this.actionList.Location = new System.Drawing.Point(183, 493);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(262, 79);
            this.actionList.TabIndex = 4;
            this.actionList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // subactionList
            // 
            this.subactionList.FormattingEnabled = true;
            this.subactionList.ItemHeight = 15;
            this.subactionList.Items.AddRange(new object[] {
            "R channel",
            "G channel",
            "B channel",
            "Grayscale"});
            this.subactionList.Location = new System.Drawing.Point(484, 493);
            this.subactionList.Name = "subactionList";
            this.subactionList.Size = new System.Drawing.Size(120, 79);
            this.subactionList.TabIndex = 5;
            this.subactionList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // thresholdMinInputBox
            // 
            this.thresholdMinInputBox.Location = new System.Drawing.Point(623, 497);
            this.thresholdMinInputBox.Name = "thresholdMinInputBox";
            this.thresholdMinInputBox.Size = new System.Drawing.Size(137, 25);
            this.thresholdMinInputBox.TabIndex = 6;
            this.thresholdMinInputBox.Text = "Input Threshold Min";
            this.thresholdMinInputBox.Visible = false;
            this.thresholdMinInputBox.TextChanged += new System.EventHandler(this.thresholdInputBox_TextChanged);
            // 
            // thresholdMaxInputBox
            // 
            this.thresholdMaxInputBox.Location = new System.Drawing.Point(623, 528);
            this.thresholdMaxInputBox.Name = "thresholdMaxInputBox";
            this.thresholdMaxInputBox.Size = new System.Drawing.Size(137, 25);
            this.thresholdMaxInputBox.TabIndex = 7;
            this.thresholdMaxInputBox.Text = "Input Threshold Max";
            this.thresholdMaxInputBox.Visible = false;
            this.thresholdMaxInputBox.TextChanged += new System.EventHandler(this.thresholdMaxInputBox_TextChanged);
            // 
            // doThreshold
            // 
            this.doThreshold.Location = new System.Drawing.Point(645, 563);
            this.doThreshold.Name = "doThreshold";
            this.doThreshold.Size = new System.Drawing.Size(75, 23);
            this.doThreshold.TabIndex = 8;
            this.doThreshold.Text = "threshold";
            this.doThreshold.UseVisualStyleBackColor = true;
            this.doThreshold.Visible = false;
            this.doThreshold.Click += new System.EventHandler(this.doThreshold_Click);
            // 
            // undoBtn
            // 
            this.undoBtn.Location = new System.Drawing.Point(930, 499);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(75, 23);
            this.undoBtn.TabIndex = 9;
            this.undoBtn.Text = "undo";
            this.undoBtn.UseVisualStyleBackColor = true;
            this.undoBtn.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 598);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.doThreshold);
            this.Controls.Add(this.thresholdMaxInputBox);
            this.Controls.Add(this.thresholdMinInputBox);
            this.Controls.Add(this.subactionList);
            this.Controls.Add(this.actionList);
            this.Controls.Add(this.afterImgBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.preImgBox);
            this.Controls.Add(this.loadBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterImgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.PictureBox preImgBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox afterImgBox;
        private System.Windows.Forms.ListBox actionList;
        private System.Windows.Forms.ListBox subactionList;
        private System.Windows.Forms.TextBox thresholdMinInputBox;
        private System.Windows.Forms.TextBox thresholdMaxInputBox;
        private System.Windows.Forms.Button doThreshold;
        private System.Windows.Forms.Button undoBtn;
    }
}

