﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessing_HW1
{
    class Threshold
    {
        public Bitmap UserDefineThreshold(Bitmap ori, int thresh, int max = 255)
        {
            Bitmap after = new Bitmap(ori);
            for (int i = 0; i < ori.Height; ++i)
            {
                for (int j = 0; j < ori.Width; ++j)
                {
                    Byte pix = ori.GetPixel(j, i).R;
                    if (pix < thresh) pix = 0;
                    else if (pix >= thresh ) pix = (byte) max;
                    after.SetPixel(j,i,Color.FromArgb(pix,pix,pix));
                }
            }

            return after;
        }
    }
}
