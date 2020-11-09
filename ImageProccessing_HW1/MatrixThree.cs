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
        int[] matrix = new int[9];
        public int mode; //mode = 3 for 3*1, mode = 9 for 3x3
        public MatrixThree(int[] a, int len)
        {
            Debug.Assert((len != 3 || len != 9), "Matrix len error");

            mode = len;
            for (int i = 0; i < len; i++)
            {
                matrix[i] = a[i];
            }
        }

        public int[] Tolist()
        {
            int[] a = new int[mode];
            
            for (int i = 0; i < mode; i++)
            {
                a[i] = matrix[i];
            }

            return a;
        }

        public int GetValue(int y, int x)
        {
            // m00, m01, m02
            // m10, m11, m12
            // m20, m21, m22
            return matrix[y * 3 + x];
        }

        public MatrixThree Mut(MatrixThree x)
        {
            int[] b = new int[x.mode];
            switch (x.mode)
            {
                case 3:
                    for (int i = 0; i < mode / 3; i++)
                    {
                        int rowSum = 0;
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
                            int rowSum = 0;
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
    }
}
