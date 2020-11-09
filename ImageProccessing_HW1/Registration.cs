﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProccessing_HW1
{
    class Registration
    {
        // let x' = Ax
        // calculate A

        int[] origin_x = new int[3];
        private int origin_x_n = 0;
        int[] origin_y = new int[3];
        private int origin_y_n = 0;
        int[] after_x = new int[3];
        private int after_x_n = 0;
        int[] after_y = new int[3];
        private int after_y_n = 0;

        public void AddPointToOrigin(int x, int y)
        {
            Debug.Assert(origin_x_n<3, "Origin Point Already full");
            origin_x[origin_x_n++] = x;
            origin_y[origin_y_n++] = y;
        }

        public void AddPointToAfter(int x, int y)
        {
            Debug.Assert(after_x_n < 3, "After Point Already full");
            after_x[after_x_n++] = x;
            after_y[after_y_n++] = y;
        }

        public String CurrentPoints()
        {
            String ret = "Origin Image:\n";
            for (int i = 0; i < origin_x_n; i++)
            {
                ret = ret + "(" + origin_x[i].ToString() + ", " + origin_y[i].ToString() + ")\n";
            }
            ret = ret + "Transformed Image:\n";
            for (int i = 0; i < after_x_n; i++)
            {
                ret = ret + "(" + after_x[i].ToString() + ", " + after_y[i].ToString() + ")\n";
            }

            return ret;
        }



        public MatrixThree FindTransform()
        {
            Debug.Assert(origin_x_n == 3 && after_x_n == 3, "Origin Points or After Point not enough");
            MatrixThree ori = new MatrixThree(new double[]{origin_x[0], origin_x[1], origin_x[2],
                                                            origin_y[0], origin_y[1], origin_y[2],
                                                            1, 1, 1}, 9);
            MatrixThree aft = new MatrixThree(new double[]{after_x[0], after_x[1], after_x[2],
                after_y[0], after_y[1], after_y[2],
                1, 1, 1}, 9);

            // aft = T * ori
            // aft * ori.inv() = T
            MatrixThree transform = aft.Mut(ori.Inv());

            double[] debg = ori.Inv().Tolist();

            return transform;
        }
    }
}
