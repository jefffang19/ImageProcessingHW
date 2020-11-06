using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProccessing_HW1
{
    public partial class Form1 : Form
    {
        private Bitmap openImag;
        private Bitmap afterImag;
        private int actionlistSelect = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // load iamge
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg Files(.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openImag = new Bitmap(openFileDialog1.FileName);
                preImgBox.Image = openImag;
                afterImgBox.Image = openImag;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // save image
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                openImag.Save(sfd.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // decide if show threshold input or sub_action select when ActionBox is Changed
            actionlistSelect = actionList.SelectedIndex;
            switch (actionlistSelect)
            {
                case 0:
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    subactionList.Items.Clear();
                    subactionList.Items.Add("R channel");
                    subactionList.Items.Add("G Channel");
                    subactionList.Items.Add("B Channel");
                    subactionList.Items.Add("Grayscale");
                    break;
                case 1:
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    subactionList.Items.Clear();
                    subactionList.Items.Add("Mean Filter");
                    subactionList.Items.Add("Median Filter");
                    break;
                case 2:
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = false;
                    HistogramEqualize histogramEq = new HistogramEqualize();
                    afterImgBox.Image = histogramEq.HisEqu(openImag);
                    break;
                case 3:
                    // show input box
                    thresholdInputBox.Visible = true;
                    subactionList.Visible = false;
                    break;
                default:
                    // hide input box
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    subactionList.Items.Clear();
                    break;
            }

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (actionlistSelect)
            {
                // rgb extract
                case 0:
                    // see what sub action
                    RgbExtract rgbExtract = new RgbExtract();
                    switch (subactionList.SelectedIndex)
                    {
                        case 0:
                            // set R
                            afterImag = rgbExtract.getR(openImag);
                            break;
                        case 1:
                            // set G
                            afterImag = rgbExtract.getG(openImag);
                            break;
                        case 2:
                            // set B
                            afterImag = rgbExtract.getB(openImag);
                            break;
                        case 3:
                            // set grayscale
                            afterImag = rgbExtract.toGrayscale(openImag);
                            break;
                    }
                    afterImgBox.Image = afterImag;
                    break;
                case 1:
                    SmoothFilter smooth = new SmoothFilter();
                    switch (subactionList.SelectedIndex)
                    {
                        case 0:
                            afterImgBox.Image = smooth.MeanFilter(openImag, 3);
                            break;
                        case 1:
                            afterImgBox.Image = smooth.MedianFilter(openImag, 3);
                            break;
                    }
                    break;
                case 2:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }
    }
}
