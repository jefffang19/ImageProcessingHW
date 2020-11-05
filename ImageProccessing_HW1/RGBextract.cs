using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessing_HW1
{
    class RgbExtract
    {
        public Bitmap getR(Bitmap openImag)
        {
            if (openImag != null)
            {
                Bitmap img = new Bitmap(openImag);
                for (int i = 0; i < img.Height; ++i)
                {
                    for (int j = 0; j < img.Width; ++j)
                    {
                        Color RGB = img.GetPixel(j, i);
                        int r = Convert.ToInt32(RGB.R);
                        img.SetPixel(j, i, Color.FromArgb(r, 0, 0));
                    }
                }

                return img;
            }
            
            return openImag;
        }

        public Bitmap getG(Bitmap openImag)
        {
            if (openImag != null)
            {
                Bitmap img = new Bitmap(openImag);
                for (int i = 0; i < img.Height; ++i)
                {
                    for (int j = 0; j < img.Width; ++j)
                    {
                        Color RGB = img.GetPixel(j, i);
                        int g = Convert.ToInt32(RGB.G);
                        img.SetPixel(j, i, Color.FromArgb(00, g, 0));
                    }
                }

                return img;
            }

            return openImag;
        }

        public Bitmap getB(Bitmap openImag)
        {
            if (openImag != null)
            {
                Bitmap img = new Bitmap(openImag);
                for (int i = 0; i < img.Height; ++i)
                {
                    for (int j = 0; j < img.Width; ++j)
                    {
                        Color RGB = img.GetPixel(j, i);
                        int b = Convert.ToInt32(RGB.B);
                        img.SetPixel(j, i, Color.FromArgb(0, 0, b));
                    }
                }

                return img;
            }
            

            return openImag;
        }

        public Bitmap toGrayscale(Bitmap openImag)
        {
            if (openImag != null)
            {
                Bitmap img = new Bitmap(openImag);
                for (int i = 0; i < img.Height; ++i)
                {
                    for (int j = 0; j < img.Width; ++j)
                    {
                        Color RGB = img.GetPixel(j, i);
                        int r = (int) (Convert.ToInt32(RGB.R) * 0.299);
                        int g = (int) (Convert.ToInt32(RGB.G) * 0.587);
                        int b = (int) (Convert.ToInt32(RGB.B) * 0.114);
                        img.SetPixel(j, i, Color.FromArgb(r, g, b));
                    }
                }

                return img;
            }


            return openImag;
        }
    }
}
