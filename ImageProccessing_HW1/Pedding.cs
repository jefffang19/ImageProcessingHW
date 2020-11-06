using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessing_HW1
{
    class Pedding
    {
        public Bitmap pedding(Bitmap ori)
        {
            // create a pedding 1 version of origin image
            Bitmap ped = new Bitmap(ori.Width + 2, ori.Height + 2);
            for (int y = 0; y < ori.Height + 2; ++y)
            {
                if (y == 0 || y == ori.Height + 1)
                {
                    for (int x = 0; x < ori.Width + 2; ++x)
                    {
                        ped.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
                else
                {
                    for (int x = 0; x < ori.Width + 2; ++x)
                    {
                        if (x == 0 || x == ori.Width + 1)
                            ped.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        else
                            ped.SetPixel(x, y, ori.GetPixel(x - 1, y - 1));
                    }
                }
            }

            return ped;
        }
    }
}
