using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessing_HW1
{
    class Sobel
    {
        private int[] vertical_filter = new int[] {1, 0, -1, 2, 0, -2, 1, 0, -1};
        private int[] horizontal_filter = new int[] {1, 2, 1, 0, 0, 0, -1, -2, -1};

        public Bitmap Vertical(Bitmap ori)
        {
            return applyFilter(ori, vertical_filter);
        }

        public Bitmap Horizontal(Bitmap ori)
        {
            return applyFilter(ori, horizontal_filter);
        }

        public Bitmap Combined(Bitmap ori)
        {
            //overlay the two results
            // let vertical be the botton layer
            Bitmap ver = applyFilter(ori, vertical_filter);
            // let horizontal be the top layer
            Bitmap hor = applyFilter(ori, horizontal_filter);
            hor = SetBlackToTransparent(hor);

            return Overlay(ver, hor);
        }

        public Bitmap applyFilter(Bitmap ori, int[] kernel)
        {
            Pedding pedding = new Pedding();
            Bitmap ped = pedding.pedding(ori);
            Bitmap after = new Bitmap(ori.Width, ori.Height);

            for (int y = 0; y < ped.Height - 2; ++y)
            {
                for (int x = 0; x < ped.Width - 2; ++x)
                {
                    int r_sum = 0, g_sum = 0, b_sum = 0;
                    // calculate sum
                    for (int i = 0; i < 3; ++i)
                    {
                        for (int j = 0; j < 3; ++j)
                        {
                            r_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).R) * kernel[i * 3 + j];
                            g_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).G) * kernel[i * 3 + j];
                            b_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).B) * kernel[i * 3 + j];
                        }
                    }
                    // if pixel > 255 then to 255, else if pixel < 0 then to 0
                    if (r_sum > 255) r_sum = 255;
                    else if (r_sum < 0) r_sum = 0;
                    if (g_sum > 255) g_sum = 255;
                    else if (g_sum < 0) g_sum = 0;
                    if (b_sum > 255) b_sum = 255;
                    else if (b_sum < 0) b_sum = 0;
                    // set pixel to mean
                    after.SetPixel(x, y, Color.FromArgb(r_sum, g_sum, b_sum));
                }
            }

            return after;
        }

        public Bitmap ThresholdSobel(Bitmap ori, Bitmap sob, int upper, int lower)
        {
            Threshold thresh = new Threshold();
            Bitmap sobThresh = thresh.UserDefineThreshold(sob, upper, lower);
            sobThresh = SetBlackToTransparent(sobThresh, true); // set the black part to transparent

            return Overlay(ori, sobThresh);
        }

        Bitmap Overlay(Bitmap bot, Bitmap top)
        {
            Bitmap overlay = new Bitmap(bot.Width, bot.Height);
            // draw the two overlay Bitmap
            /*using (Graphics g = Graphics.FromImage(overlay))
            {
                g.Clear(Color.Black); //background

                // draw two layers
                g.DrawImage(bot, new Rectangle(0, 0, bot.Width, bot.Height));
                g.DrawImage(top, new Rectangle(0, 0, top.Width, top.Height));
            }*/
            for (int i = 0; i < bot.Height; i++)
            {
                for (int j = 0; j < bot.Width; j++)
                {
                    overlay.SetPixel(j, i, bot.GetPixel(j,i));
                    if(top.GetPixel(j,i).ToArgb() == Color.Green.ToArgb())
                        overlay.SetPixel(j,i,top.GetPixel(j,i));
                }
            }

            return overlay;
        }

        Bitmap SetBlackToTransparent(Bitmap ori, Boolean green = false)
        {
            Bitmap tmp = new Bitmap(ori);
            for (int i = 0; i < tmp.Height; ++i)
            {
                for (int j = 0; j < tmp.Width; ++j)
                {
                    if (tmp.GetPixel(j, i).ToArgb() == Color.Black.ToArgb())
                    {
                        tmp.SetPixel(j,i,Color.Transparent);
                    }
                    // if not black, set to green
                    else if(green)
                    {
                        tmp.SetPixel(j,i,Color.Green);
                    }
                }
            }

            return tmp;
        }
    }
}
