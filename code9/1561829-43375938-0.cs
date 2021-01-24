    public static double[] trilaterate2DLinear(double[] pA, double[] pB, double[] pC, double rA, double rB, double rC) {
            //Convert doubles to vectors for processing
            Vector<double> vA = Vector<double>.Build.Dense(pA);
            Vector<double> vB = Vector<double>.Build.Dense(pB);
            Vector<double> vC = Vector<double>.Build.Dense(pC);
            //Declare elements of b vector
            //bBA = 1/2 * (rA^2 - rB^2 + dBA^2)
            double[] b = {0, 0};
            b[0] = 0.5 * (Math.Pow(rA, 2) - Math.Pow(rB, 2) + Math.Pow(getDistance(pB, pA), 2));
            b[1] = 0.5 * (Math.Pow(rA, 2) - Math.Pow(rC, 2) + Math.Pow(getDistance(pC, pA), 2));
            //Convert b array to vector form
            Vector<double> vb = Vector<double>.Build.Dense(b);
            //Build A array
            //A =   {x2 -x1, y2 - y1}
            //      {x3 - x1, y3 - y1}
            double[,] A =  { { pB[0] - pA[0], pB[1] - pA[1] }, { pC[0] - pA[0], pC[1] - pA[1] } };
            //Convert A to Matrix form
            Matrix<double> mA = Matrix<double>.Build.DenseOfArray(A);
            //Declare Transpose of A matrix;
            Matrix<double> mAT = mA.Transpose();
            //Declare solution vector x to 0
            Vector<double> x = Vector<double>.Build.Dense(2);
            //Check if A*AT is non-singular (non 0 determinant)
            double det = mA.Multiply(mAT).Determinant();
            if (mA.Multiply(mAT).Determinant() > 0.1)
            {
                //x = ((AT * A)^-1)*AT*b
               // x = (((mA.Multiply(mAT)).Inverse()).Multiply(mAT)).Multiply(vb);
                x = (mA.Transpose() * mA).Inverse() * (mA.Transpose() * vb);
            }
            else 
            { 
                //TODO case for A*AT to be singular
                x = (((mA.Multiply(mAT)).Inverse()).Multiply(mAT)).Multiply(vb);
            }
            //final position is x + vA
            //return as double so as not
            return (x.Add(vA)).ToArray();
        }
