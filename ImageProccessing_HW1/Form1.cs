using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            switch (actionList.SelectedIndex)
            {
                case 0:
                    // hide input box
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    break;
                case 1:
                    // hide input box
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    break;
                case 2:
                    // hide input box
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    break;
                case 3:
                    // show input box
                    thresholdInputBox.Visible = true;
                    subactionList.Visible = false;
                    break;
                case 4:
                    // hide input box
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    break;
                case 5:
                    // hide input box
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    break;
                case 6:
                    // hide input box
                    thresholdInputBox.Visible = false;
                    subactionList.Visible = true;
                    break;
            }

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
