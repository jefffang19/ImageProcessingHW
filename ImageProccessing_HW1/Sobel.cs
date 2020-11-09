﻿using System;
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

        public Bitmap vertical(Bitmap ori)
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
                            r_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).R) * vertical_filter[i*3+j];
                            g_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).G) * vertical_filter[i * 3 + j];
                            b_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).B) * vertical_filter[i * 3 + j];
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
    }
}
