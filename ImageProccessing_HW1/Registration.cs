using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProccessing_HW1
{
    class Registration
    {
        // let x' = Ax
        // calculate A
        private const int point_n = 4;

        int[] origin_x = new int[point_n];
        private int origin_x_n = 0;
        int[] origin_y = new int[point_n];
        private int origin_y_n = 0;
        int[] after_x = new int[point_n];
        private int after_x_n = 0;
        int[] after_y = new int[point_n];
        private int after_y_n = 0;

        private MatrixThree transform;

        private float[] cx;
        private float[] cy;

        public void AddPointToOrigin(int x, int y)
        {
            Debug.Assert(origin_x_n< point_n, "Origin Point Already full");
            origin_x[origin_x_n++] = x;
            origin_y[origin_y_n++] = y;
        }

        public void AddPointToAfter(int x, int y)
        {
            Debug.Assert(after_x_n < point_n, "After Point Already full");
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

        public Bitmap RegisterImage(Bitmap aft)
        {
            Bitmap ori = new Bitmap(aft.Width, aft.Height);
            for (int i = 0; i < ori.Height; i++)
            {
                for (int j = 0; j < ori.Width; j++)
                {
                    double[] afterPoints = CleanTransitionMatrix().Mut(new MatrixThree(new double[] {j, i, 1}, 3)).Tolist();

                    int[] stemPoints = new int[2];
                    for (int k = 0; k < 2; k++)
                    {
                        if (afterPoints[k] < 0) stemPoints[k] = 0;
                        else stemPoints[k] = (int) Math.Round(afterPoints[k]);
                    }
                    if (stemPoints[0] >= aft.Width) stemPoints[0] = aft.Width - 1;
                    if (stemPoints[1] >= aft.Height) stemPoints[1] = aft.Height - 1;

                    ori.SetPixel(j,i,aft.GetPixel(stemPoints[0], stemPoints[1]));
                    //TODO: shift picture
                }
            }

            return ori;
        }

        public Bitmap NewRegisterImage(Bitmap aft, int wid, int hi)
        {
            Bitmap ori = new Bitmap(wid, hi);
            for (int i = 0; i < ori.Height; i++)
            {
                for (int j = 0; j < ori.Width; j++)
                {
                    float _x = j * cx[0] + i * cx[1] + i * j * cx[2] + cx[3];
                    float _y = j * cy[0] + i * cy[1] + i * j * cy[2] + cy[3];
                    int[] stemPoints = new int[2];

                    if (_x < 0) stemPoints[0] = 0;
                    else stemPoints[0] = (int)_x;
                    if (_y < 0) stemPoints[1] = 0;
                    else stemPoints[1] = (int)_y;

                    if (stemPoints[0] >= aft.Width) stemPoints[0] = aft.Width - 1;
                    if (stemPoints[1] >= aft.Height) stemPoints[1] = aft.Height - 1;

                    ori.SetPixel(j, i, aft.GetPixel(stemPoints[0], stemPoints[1]));
                }
            }

            return ori;
        }


        public MatrixThree FindTransform()
        {
            Debug.Assert(origin_x_n == point_n && after_x_n == point_n, "Origin Points or After Point not enough");
            MatrixThree ori = new MatrixThree(new double[]{origin_x[0], origin_x[1], origin_x[2],
                                                            origin_y[0], origin_y[1], origin_y[2],
                                                            1, 1, 1}, 9);
            MatrixThree aft = new MatrixThree(new double[]{after_x[0], after_x[1], after_x[2],
                after_y[0], after_y[1], after_y[2],
                1, 1, 1}, 9);

            // aft = T * ori
            // aft * ori.inv() = T
            transform = aft.Mut(ori.Inv());

            NewFindTransform(); // find cx and cy

            return transform;
        }

        void NewFindTransform()
        {
            Matrix4x4 oriMatrix = new Matrix4x4(origin_x[0], origin_x[1], origin_x[2], origin_x[3], 
                                                origin_y[0], origin_y[1], origin_y[2], origin_y[3],
                                                origin_x[0]*origin_y[0], origin_x[1]*origin_y[1], origin_x[2]*origin_y[2], origin_x[3]*origin_y[3],
                                                1.0f, 1.0f, 1.0f, 1.0f);
            Matrix4x4 aftMatrix = new Matrix4x4(after_x[0], after_x[1], after_x[2], after_x[3],
                                                after_y[0], after_y[1], after_y[2], after_y[3],
                                                0f, 0f, 0f, 0f,
                                                0f, 0f, 0f, 0f);
            Matrix4x4 oriInvMatrix;
            Matrix4x4.Invert(oriMatrix, out oriInvMatrix);
            Matrix4x4 transformMatrix = Matrix4x4.Multiply(aftMatrix, oriInvMatrix);

            cx = new float[]{transformMatrix.M11, transformMatrix.M12, transformMatrix.M13, transformMatrix.M14};
            cy = new float[]{transformMatrix.M21, transformMatrix.M22, transformMatrix.M23, transformMatrix.M24};
        }

        double CalculateZoomX()
        {
            return Math.Sqrt(Math.Pow(after_x[0] - after_x[1], 2) + Math.Pow(after_y[0] - after_y[1], 2))/
                Math.Sqrt(Math.Pow(origin_x[0]-origin_x[1],2) + Math.Pow(origin_y[0]-origin_y[1],2));
        }

        double CalculateZoomY()
        {
            return Math.Sqrt(Math.Pow(after_x[0] - after_x[2], 2) + Math.Pow(after_y[0] - after_y[2], 2)) /
                   Math.Sqrt(Math.Pow(origin_x[0] - origin_x[2], 2) + Math.Pow(origin_y[0] - origin_y[2], 2));
        }

        public string CalculateRegAttr(Bitmap refer, Bitmap reg)
        {
            double[] scalefac = CalculateScaleFactor();
            string s = string.Format("Scaling Factor x:{0}\nScaling Factor y:{1}\nCosine Angle theta:{2}\nIntensity Difference:{3}\n", scalefac[0], scalefac[1], CalculateCosAngle(), IntensityDiff(refer, reg));

            return s;
        }

        public double[] CalculateScaleFactor()
        {
            double[] scal = ScalingMatrix().Tolist();
            return new double[]{scal[0], scal[4]};
        }

        public double CalculateCosAngle()
        {
            MatrixThree rotate = RotateMatrix();
            double cosAngle = (rotate.Tolist()[0] + rotate.Tolist()[4])/2;
            return Radian2Degree(Math.Acos(cosAngle));
        }

        double Radian2Degree(double rad)
        {
            return rad * 180 / Math.PI;
        }

        MatrixThree RotateMatrix()
        {
            Debug.Assert(origin_x_n == point_n && after_x_n == point_n, "Origin Points or After Point not enough");
            return TranslateMatrix().Inv().Mut(ScalingMatrix().Inv()).Mut(FindTransform());
        }

        MatrixThree ScalingMatrix()
        {
            Debug.Assert(origin_x_n == point_n && after_x_n == point_n, "Origin Points or After Point not enough");
            return new MatrixThree(new double[]{CalculateZoomX(),0,0,0,CalculateZoomY(),0,0,0,1},9);
        }

        MatrixThree TranslateMatrix()
        {
            Debug.Assert(origin_x_n == point_n && after_x_n == point_n, "Origin Points or After Point not enough");
            return new MatrixThree(new double[] { 1, 0, transform.Tolist()[2], 0, 1, transform.Tolist()[5], 0, 0, 1 }, 9);
        }

        MatrixThree CleanTransitionMatrix()
        {
            return ScalingMatrix().Mut(RotateMatrix());
        }

        double IntensityDiff(Bitmap refer, Bitmap reg)
        {
            double sum = 0;
            for (int i = 0; i < refer.Height; i++)
            {
                for (int j = 0; j < refer.Width; j++)
                {
                    sum += Math.Abs(refer.GetPixel(j, i).R - reg.GetPixel(j, i).R);
                }
            }

            return sum / (refer.Height * refer.Width);
        }
    }
}
