    using System;
    
    namespace SO_c
    {
        internal static class Program
        {
            private static void Main()
            {
                while (true)
                {
                    var n = int.Parse(Console.ReadLine());
                    if (n < 1 || n % 2 == 0)
                        continue;
                    var matrix = new bool[n, n];
                    FillDiamond(matrix);
                    for (var y = 0; y < matrix.GetLength(1); y++)
                    {
                        for (var x = 0; x < matrix.GetLength(0); x++)
                            Console.Write(matrix[x, y] ? "█" : " ");
                        Console.WriteLine();
                    }
                }
            }
            private static void FillLine(int line, int count, bool[,] matrix)
            {
                //Firstly we have to evaluate the offset:
                var offset = (matrix.GetLength(0) - count) / 2;
                //Then we have to fill the line
                for (var x = offset; x < offset + count; x++)
                    matrix[x, line] = true;
            }
    
            public static void FillDiamond(bool[,] matrix)
            {
                var count = 1;
                for (var line = 0; line < matrix.GetLength(1) / 2; line++)
                {
                    FillLine(line, count, matrix);
                    count += 2;
                }
                FillLine(matrix.GetLength(1) / 2, count, matrix);
                count = 1;
                for (var line = matrix.GetLength(1) - 1; line > matrix.GetLength(1) / 2; line--)
                {
                    FillLine(line, count, matrix);
                    count += 2;
                }
            }
        }
    }
