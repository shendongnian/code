    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[,] chromosome = {
                    {1,0,1,1,1,0,1,1,1,1,},
                    {1,0,1,1,1,1,1,1,1,0,},
                    {1,0,0,0,0,1,0,0,0,0,},
                    {0,1,0,1,0,1,0,1,1,1,},
                    {1,1,1,1,0,0,1,1,1,1,},
                    {1,1,1,1,0,1,1,1,0,0,},
                    {1,1,0,0,0,0,0,1,1,1,},
                    {1,0,1,1,0,0,0,1,1,0,},
                    {1,1,0,0,0,0,0,0,0,0,},
                    {0,0,0,1,0,0,0,1,0,0,}
                           };
                Boolean results11 = TestZero(chromosome, 1, 1);
                Boolean results85 = TestZero(chromosome, 8, 5);
            }
            static Boolean TestZero(int[,] array, int rowIndex, int colIndex)
            {
                if((rowIndex == 0) || (rowIndex >= array.GetUpperBound(0)) || (colIndex == 0) || (colIndex >= array.GetUpperBound(1))) return false;
                for(int i = 0; i <= rowIndex; i++)
                {
                    for(int j = 0; j <= colIndex; j++)
                    {
                        if((i != rowIndex) && (j != colIndex))
                        {
                            if(array[i,j] == 1) return false;
                        }
                    }
                }
                return true;
            }
        }
    }
