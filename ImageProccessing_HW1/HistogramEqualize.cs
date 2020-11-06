using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessing_HW1
{
    class HistogramEqualize
    {
        public Bitmap HisEqu(Bitmap ori)
        {
            Dictionary<byte, int> r_map = new Dictionary<byte, int>();
            // calculate frequency
            for (int i = 0; i < ori.Height; ++i)
            {
                for (int j = 0; j < ori.Width; ++j)
                {
                    Color pix = ori.GetPixel(j, i);
                    if (r_map.ContainsKey(pix.R))
                        ++r_map[pix.R];
                    else
                        r_map.Add(pix.R, 1);
                }
            }
            // calculate prob
            Dictionary<byte, double> r_map_prob = new Dictionary<byte, double>();
            double freq_sum = 0;
            foreach (var v in r_map)
            {
                freq_sum += v.Value;
            }

            foreach (var v in r_map)
            {
                r_map_prob.Add(v.Key, v.Value/freq_sum);
            }

            //calculate cdf
            Dictionary<byte, double> r_map_cdf = new Dictionary<byte, double>();
            // sort the prob by key
            r_map_prob = r_map_prob.OrderBy(i => i.Key).ToDictionary(i => i.Key, i => i.Value);
            // cal cdf
            double prob_sum = 0, cdf_min = 0, cdf_max = 0;
            bool first = true;
            foreach (var v in r_map_prob)
            {
                // get cdf min
                if (first)
                {
                    first = false;
                    cdf_min = v.Value;
                }
                prob_sum += v.Value; // calculate cdf => sum(prob)
                cdf_max = prob_sum; // get cdf max
                r_map_cdf.Add(v.Key, prob_sum);
            }

            // apply equalize to bitmap
            Bitmap after = new Bitmap(ori.Width, ori.Height);
            for (int i = 0; i < ori.Height; ++i)
            {
                for (int j = 0; j < ori.Width; ++j)
                {
                    Color pix = ori.GetPixel(j, i);
                    int r = (int) Math.Round((r_map_cdf[pix.R] - cdf_min)/(cdf_max - cdf_min) *255) ;
                    after.SetPixel(j,i,Color.FromArgb(r,r,r));
                }
            }

            return after;
        }

    }
}
