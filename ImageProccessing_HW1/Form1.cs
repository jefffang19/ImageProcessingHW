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
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProccessing_HW1
{
    public partial class Form1 : Form
    {
        private Stack<Bitmap> undoImages = new Stack<Bitmap>();
        private Stack<Bitmap> redoImages = new Stack<Bitmap>();
        private Bitmap openImag;
        private Bitmap afterImag;
        private int actionlistSelect = 0;
        private int thresh = 0;

        Registration reg = new Registration();
        private int oriImagClicks = 0;
        private int aftImagClick = 0;
         
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
            
            undoImages.Clear();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // if more then 4 clicked
            if (oriImagClicks >= 4) return;

            // get mouse args
            var mouseArgs = (MouseEventArgs)e;
            reg.AddPointToOrigin(mouseArgs.X, mouseArgs.Y);
            ++oriImagClicks;

            // update coordinate display
            mouseLabel.Text = reg.CurrentPoints();
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
                    thresholdMinInputBox.Visible = false;
                    subactionList.Visible = true;
                    doThreshold.Visible = false;
                    regAttr.Visible = false;
                    registration.Visible = false;
                    loadImg2.Visible = false;
                    beforeHist.Visible = false;
                    afterHist.Visible = false;
                    subactionList.Items.Clear();
                    subactionList.Items.Add("R channel");
                    subactionList.Items.Add("G Channel");
                    subactionList.Items.Add("B Channel");
                    subactionList.Items.Add("Grayscale");
                    break;
                case 1:
                    thresholdMinInputBox.Visible = false;
                    subactionList.Visible = true;
                    doThreshold.Visible = false;
                    regAttr.Visible = false;
                    registration.Visible = false;
                    loadImg2.Visible = false;
                    beforeHist.Visible = false;
                    afterHist.Visible = false;
                    subactionList.Items.Clear();
                    subactionList.Items.Add("Mean Filter");
                    subactionList.Items.Add("Median Filter");
                    break;
                case 2:
                    thresholdMinInputBox.Visible = false;
                    subactionList.Visible = false;
                    doThreshold.Visible = false;
                    regAttr.Visible = false;
                    registration.Visible = false;
                    loadImg2.Visible = false;
                    beforeHist.Visible = true;
                    afterHist.Visible = true;
                    HistogramEqualize histogramEq = new HistogramEqualize();
                    afterImgBox.Image = histogramEq.HisEqu(openImag);
                    //after image process function, add undo
                    undoImages.Push(new Bitmap(openImag));
                    openImag = new Bitmap(afterImgBox.Image);
                    afterHist_Show();
                    beforeHist_Show();
                    break;
                case 3:
                    // show input box
                    thresholdMinInputBox.Visible = true;
                    subactionList.Visible = false;
                    doThreshold.Visible = true;
                    regAttr.Visible = false;
                    registration.Visible = false;
                    loadImg2.Visible = false;
                    beforeHist.Visible = false;
                    afterHist.Visible = false;
                    break;
                case 4:
                    thresholdMinInputBox.Visible = false;
                    subactionList.Visible = true;
                    doThreshold.Visible = false;
                    regAttr.Visible = false;
                    registration.Visible = false;
                    loadImg2.Visible = false;
                    beforeHist.Visible = false;
                    afterHist.Visible = false;
                    subactionList.Items.Clear();
                    subactionList.Items.Add("Vertical");
                    subactionList.Items.Add("Horizontal");
                    subactionList.Items.Add("Combined");
                    break;
                case 5:
                    thresholdMinInputBox.Visible = true;
                    subactionList.Visible = false;
                    doThreshold.Visible = true;
                    regAttr.Visible = false;
                    registration.Visible = false;
                    loadImg2.Visible = false;
                    beforeHist.Visible = false;
                    afterHist.Visible = false;
                    break;
                case 6:
                    //TODO: undo function
                    oriImagClicks = 0;
                    aftImagClick = 0;
                    thresholdMinInputBox.Visible = false;
                    subactionList.Visible = false;
                    doThreshold.Visible = false;
                    registration.Visible = true;
                    mouseLabel.Visible = true;
                    loadImg2.Visible = true;
                    beforeHist.Visible = false;
                    afterHist.Visible = false;
                    mouseLabel.Text = "Mouse Click:Leftup,\nRightup,\nLeftDown\nRightDown\n";
                    break;
                default:
                    // hide input box
                    thresholdMinInputBox.Visible = false;
                    subactionList.Visible = true;
                    doThreshold.Visible = false;
                    subactionList.Items.Clear();
                    mouseLabel.Visible = false;
                    regAttr.Visible = false;
                    registration.Visible = false;
                    loadImg2.Visible = false;
                    beforeHist.Visible = false;
                    afterHist.Visible = false;
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
                case 4:
                    Sobel sobel = new Sobel();
                    switch (subactionList.SelectedIndex)
                    {
                        case 0:
                            afterImgBox.Image = sobel.Vertical(openImag);
                            break;
                        case 1:
                            afterImgBox.Image = sobel.Horizontal(openImag);
                            break;
                        case 2:
                            afterImgBox.Image = sobel.Combined(openImag);
                            break;
                    }
                    break;
                default:
                    Debug.Assert(false,"ListBox should not apper error");
                    break;
            }
            undoImages.Push(new Bitmap(openImag));
            openImag = new Bitmap(afterImgBox.Image);
        }

        private void thresholdInputBox_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(thresholdMinInputBox.Text) && thresholdMinInputBox.Text.All(Char.IsDigit))
                thresh = Convert.ToInt32(thresholdMinInputBox.Text);
        }

        private void thresholdMaxInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void doThreshold_Click(object sender, EventArgs e)
        {
            if (actionList.SelectedIndex == 3)
            {
                Threshold thresh = new Threshold();
                afterImgBox.Image = thresh.UserDefineThreshold(openImag, this.thresh);
            }
            else if (actionList.SelectedIndex == 5)
            {
                Sobel _sobel = new Sobel();
                Bitmap originalImage = undoImages.First();
                afterImgBox.Image = _sobel.ThresholdSobel(originalImage, (Bitmap)afterImgBox.Image, thresh);
            }
            else
            {
                Debug.Assert(false, "Threshold Button should not appear error");
            }
            //after image process function, add undo
            undoImages.Push(new Bitmap(openImag));
            openImag = new Bitmap(afterImgBox.Image);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // get openImage stack top
            openImag = undoImages.First();
            afterImgBox.Image = openImag;
            // pop the undo
            undoImages.Pop();
        }

        private void afterImgBox_Click(object sender, EventArgs e)
        {
            // if more then 4 clicked
            if (aftImagClick >= 4) return;

            // get mouse args
            var mouseArgs = (MouseEventArgs)e;
            reg.AddPointToAfter(mouseArgs.X, mouseArgs.Y);
            ++aftImagClick;

            // update coordinate display
            mouseLabel.Text = reg.CurrentPoints();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            // load iamge
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files (.bmp)|*.bmp|Jpeg Files(.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                afterImag = new Bitmap(openFileDialog1.FileName);
                afterImgBox.Image = afterImag;
            }
        }

        private void registration_Click(object sender, EventArgs e)
        {
            double[] transitionMatrix = reg.FindTransform().Tolist(); // this function call is required
            //double cosAngle = reg.CalculateCosAngle();
            //double[] scaleFactory = reg.CalculateScaleFactor();
            afterImgBox.Image = reg.NewRegisterImage(afterImag, openImag.Width, openImag.Height);
            regAttr.Visible = true;
            regAttr.Text = reg.CalculateRegAttr(openImag, (Bitmap) afterImgBox.Image);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void beforeHist_Show()
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;

            Dictionary<int, int> intesFreq = new Dictionary<int, int>();
            // Calculate Gray vale and Frequency
            for (int i = 0; i < preImgBox.Image.Height; i++)
            {
                for (int j = 0; j < preImgBox.Image.Width; j++)
                {
                    int grayValue = ((Bitmap) preImgBox.Image).GetPixel(j, i).R;
                    if(intesFreq.ContainsKey(grayValue))
                        ++intesFreq[grayValue];
                    else
                    {
                        intesFreq.Add(grayValue, 1);
                    }
                }
            }

            // Calculate Histogram
            // x = gray value
            // y = freq
            for (int i = 0; i < 256; i++)
            {
                if(intesFreq.ContainsKey(i))
                    series.Points.AddXY(i, intesFreq[i]);
                else
                {
                    series.Points.AddXY(i, 0);
                }
            }

            beforeHist.Series.Clear();
            beforeHist.Series.Add(series);
        }

        private void afterHist_Show()
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;

            Dictionary<int, int> intesFreq = new Dictionary<int, int>();
            // Calculate Gray vale and Frequency
            for (int i = 0; i < afterImgBox.Image.Height; i++)
            {
                for (int j = 0; j < afterImgBox.Image.Width; j++)
                {
                    int grayValue = ((Bitmap)afterImgBox.Image).GetPixel(j, i).R;
                    if (intesFreq.ContainsKey(grayValue))
                        ++intesFreq[grayValue];
                    else
                    {
                        intesFreq.Add(grayValue, 1);
                    }
                }
            }

            // Calculate Histogram
            // x = gray value
            // y = freq
            for (int i = 0; i < 256; i++)
            {
                if (intesFreq.ContainsKey(i))
                    series.Points.AddXY(i, intesFreq[i]);
                else
                {
                    series.Points.AddXY(i, 0);
                }
            }

            afterHist.Series.Clear();
            afterHist.Series.Add(series);
        }
    }
}
