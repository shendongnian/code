    using System;
    using MathNet.Numerics.LinearAlgebra;
    using MathNet.Numerics.LinearAlgebra.Double;
    
    
    namespace check1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Matrix<double> A = DenseMatrix.OfArray(new double[,] {
            {1,1,1,1},
            {1,2,3,4},
            {4,3,2,1}});
                Vector<double>[] nullspace = A.Kernel();
    
                // verify: the following should be approximately (0,0,0)
                Console.Write(A * (2 * nullspace[0] - 3 * nullspace[1]));
                Console.Read();
            }
        }
    }
