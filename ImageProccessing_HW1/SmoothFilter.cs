using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessing_HW1
{
    class SmoothFilter
    {
        public Bitmap MeanFilter(Bitmap ori, int kernelSize)
        {
            //apply filter
            if (ori != null)
            {
                Pedding pedding = new Pedding();

                Bitmap ped = pedding.pedding(ori); // pedding 1

                Bitmap after = new Bitmap(ori.Width, ori.Height);
                for (int y = 0; y < ped.Height - kernelSize + 1; ++y)
                {
                    for (int x = 0; x < ped.Width - kernelSize + 1; ++x)
                    {
                        int r_sum = 0, g_sum = 0, b_sum = 0;
                        // calculate sum
                        for (int i = 0; i < kernelSize; ++i)
                        {
                            for (int j = 0; j < kernelSize; ++j)
                            {
                                r_sum += Convert.ToInt32(ped.GetPixel(x + j, y+i).R);
                                g_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).G);
                                b_sum += Convert.ToInt32(ped.GetPixel(x + j, y + i).B);
                            }
                        }
                        // set pixel to mean
                        after.SetPixel(x, y, Color.FromArgb((int) (r_sum / Math.Pow(kernelSize, 2)), (int)(g_sum / Math.Pow(kernelSize, 2)), (int)(b_sum / Math.Pow(kernelSize, 2))));
                    }
                }
                return after;
            }
            else
            {
                return ori;
            }
            
        }

        public Bitmap MedianFilter(Bitmap ori, int kernelSize)
        {
            //apply filter
            if (ori != null)
            {
                Pedding pedding = new Pedding();

                Bitmap ped = pedding.pedding(ori); // pedding 1

                Bitmap after = new Bitmap(ori.Width, ori.Height);
                for (int y = 0; y < ped.Height - kernelSize + 1; ++y)
                {
                    for (int x = 0; x < ped.Width - kernelSize + 1; ++x)
                    {
                        int[] r_sum = new int[kernelSize * kernelSize];
                        int[] g_sum = new int[kernelSize*kernelSize];
                        int[] b_sum = new int[kernelSize*kernelSize];
                        // calculate median
                        for (int i = 0; i < kernelSize; ++i)
                        {
                            for (int j = 0; j < kernelSize; ++j)
                            {
                                r_sum[i * kernelSize + j] = Convert.ToInt32(ped.GetPixel(x + j, y + i).R);
                                g_sum[i * kernelSize + j] = Convert.ToInt32(ped.GetPixel(x + j, y + i).G);
                                b_sum[i * kernelSize + j] = Convert.ToInt32(ped.GetPixel(x + j, y + i).B);
                            }
                        }
                        // sort
                        Array.Sort(r_sum);
                        Array.Sort(g_sum);
                        Array.Sort(b_sum);
                        // set pixel to mean
                        after.SetPixel(x, y, Color.FromArgb(r_sum[kernelSize * kernelSize / 2], g_sum[kernelSize * kernelSize / 2], b_sum[kernelSize * kernelSize / 2]));
                    }
                }
                return after;
            }
            else
            {
                return ori;
            }
        }
    }
}
