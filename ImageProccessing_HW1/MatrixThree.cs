using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProccessing_HW1
{
    class MatrixThree
    {
        // M = [ [a,b,c],
        //      [d,e,f],
        //      [g,h,i] ]
        double[] matrix = new double[9];
        public int mode; //mode = 3 for 3*1, mode = 9 for 3x3
        public MatrixThree(double[] a, int len)
        {
            Debug.Assert((len != 3 || len != 9), "Matrix len error");

            mode = len;
            for (int i = 0; i < len; i++)
            {
                matrix[i] = a[i];
            }
        }

        public double[] Tolist()
        {
            double[] a = new double[mode];
            
            for (int i = 0; i < mode; i++)
            {
                a[i] = matrix[i];
            }

            return a;
        }

        public double GetValue(int y, int x)
        {
            // m00, m01, m02
            // m10, m11, m12
            // m20, m21, m22
            return matrix[y * 3 + x];
        }

        public MatrixThree Mut(MatrixThree x)
        {
            double[] b = new double[x.mode];
            switch (x.mode)
            {
                case 3:
                    for (int i = 0; i < mode / 3; i++)
                    {
                        double rowSum = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            rowSum += x.GetValue(0, j) * GetValue(i, j);
                        }

                        b[i] = rowSum;
                        rowSum = 0;
                    }

                    break;
                case 9:
                    for (int i = 0; i < mode / 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            double rowSum = 0;
                            for (int k = 0; k < 3; k++)
                            {
                                rowSum += GetValue(i, k) * x.GetValue(k, j);
                            }

                            b[i * 3 + j] = rowSum;
                            rowSum = 0;
                        }
                    }

                    break;
            }

            MatrixThree mat = new MatrixThree(b, x.mode);
            return mat;
        }

        public MatrixThree Inv()
        {
            var e = matrix[4];
            var i = matrix[8];
            var f = matrix[5];
            var h = matrix[7];
            var d = matrix[3];
            var g = matrix[6];
            var b = matrix[1];
            var c = matrix[2];
            var a = matrix[0];
            double[] inv = new double[]
            {
                e * i - f * h,
                -d * i + f * g,
                d * h - e * g,
                -b * i + c * h,
                a * i - c * g,
                -a * h + b * g,
                b * f - c * e,
                -a * f + c * d,
                a * e - b * d,
            };

            inv = new MatrixThree(inv,9).Transpose().Tolist();

            double det = a * (e * i - f * h) +
                      b * (-d * i + f * g) +
                      c * (d * h - e * g);
            for (int v = 0; v < 9; v++)
            {
                inv[v] /= det;
            }

            return new MatrixThree(inv, 9);
        }

        public MatrixThree Transpose()
        {
            double[] trans = new double[]
            {
                matrix[0], matrix[3], matrix[6],
                matrix[1], matrix[4], matrix[7],
                matrix[2], matrix[5], matrix[8],
            };
            return new MatrixThree(trans, 9);
        }
    }
}
