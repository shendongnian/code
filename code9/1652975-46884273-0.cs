        static void Main(string[] args)
        {
            int[][] parentMatrix = new int[][]
            {
                new int [] { 1, 2, 3 },
                new int [] { 4, 5, 6 },
                new int [] { 7, 8, 9 }
            };
            var chunks = GetSubMatrices(parentMatrix, 2);
            
            Console.WriteLine(chunks);
        }
        static List<int[][]> GetSubMatrices(int[][] parentMatrix, int m)
        {
            int n = parentMatrix.Length > m ? parentMatrix.Length : throw new InvalidOperationException("You can't use a matrix smaller than the chunk size");
            var chunks = new List<int[][]>();
            int movLimit = n - m + 1;
            var allCount = Math.Pow(movLimit, 2);
            
            for (int selRow = 0; selRow < movLimit; selRow ++)
            {
                for (int selCol = 0; selCol < movLimit; selCol ++)
                {
                    // this is start position of the chunk
                    var chunk = new int[m][];
                    for (int row = 0; row < m; row++)
                    {
                        chunk[row] = new int[m];
                        for (int col = 0; col < m; col++)
                        {
                            chunk[row][col] = parentMatrix[selRow + row][selCol + col];
                        }
                    }
                    chunks.Add(chunk);
                }
            }
            
            return chunks;
        }
