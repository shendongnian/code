     public class Class1
        {
            double[] C;
            double[][] pos;   
            public double S;
            double[] X;
            List<double[][]> List1 = new List<double[][]>();
    
            public Class1()
            {
            }
    
            public void runCode()
            {
    
                pos = new double[10][];
                for (int ii = 0; ii < 10; ii++)
                {
                    pos[ii] = new double[5];
                    for (int jj = 0; jj < 5; ++jj)
                        pos[ii][jj] = 0;
                }
    
                List1 = ListExtensions.ChunkBy(pos, 1);
                #region 
                X = new double[5];
    
                for (int jj = 0; jj < 5; ++jj)
                {
                    X[jj] = 0.0;
                }
    
                S = 10000000000000000000;
                #endregion
    
                C = new double[List1[0].Length];
                for (int ii = 0; ii < List1[0].Length; ++ii)
                {
                    for (int jj = 0; jj < 5; ++jj)
                        List1[0][ii][jj] = 1;
    
    
                    if (C[ii] < S)
                    {
                        List1[0][ii].CopyTo(X, 0);
                    }
    
                }
                //======================= Before
                for (int jj = 0; jj < 5; ++jj)
                    Console.WriteLine("----------------    " + X[jj]);
    
    
                Console.WriteLine("\n");
                for (int ii = 0; ii < List1[0].Length; ++ii)
                   for (int jj = 0; jj < 5; jj++)
                       List1[0][ii][jj] = 5;
    
                 Console.WriteLine("//======================= After");
    
                for (int jj = 0; jj < 5; ++jj)
                    Console.WriteLine("----------------    " + X[jj]);
    
                Console.Read();
            }  
        } // end class   
    }
