using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
                Bitmap after = new Bitmap(ori);
                for (int y = 0; y < ori.Height - kernelSize + 1; ++y)
                {
                    for (int x = 0; x < ori.Width - kernelSize + 1; ++x)
                    {
                        int r_sum = 0, g_sum = 0, b_sum = 0;
                        // calculate sum
                        for (int i = 0; i < kernelSize; ++i)
                        {
                            for (int j = 0; j < kernelSize; ++j)
                            {
                                r_sum += Convert.ToInt32(after.GetPixel(x + j, y+i).R);
                                g_sum += Convert.ToInt32(after.GetPixel(x + j, y + i).G);
                                b_sum += Convert.ToInt32(after.GetPixel(x + j, y + i).B);
                            }
                        }
                        // set pixel to mean
                        for (int i = 0; i < kernelSize; ++i)
                        {
                            for (int j = 0; j < kernelSize; ++j)
                            {
                                after.SetPixel(x+j, y+i, Color.FromArgb((int) (r_sum / Math.Pow(kernelSize, 2)), (int)(g_sum / Math.Pow(kernelSize, 2)), (int)(b_sum / Math.Pow(kernelSize, 2))));
                            }
                        }
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
