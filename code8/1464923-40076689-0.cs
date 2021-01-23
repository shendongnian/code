    static void SumOfPlatform(int[,] data)
            {
                int sum = 0;
                int x = 0;
                int y = 0;
                int maxSum = 0;
                for (int i = 0; i < data.GetLength(0) - 2; i++)
                {
                    for (int j = 0; j < data.GetLength(1) - 2; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                sum += data[i + k, j + l]; //only Change
                            }
                        }
                        if (maxSum < sum)
                        {
                            maxSum = sum;
                            x = i;
                            y = j;
                        }
                        sum = 0;
                    }
                }
                Console.WriteLine("Sum: {0}\nPosition: {1} {2}", maxSum, x, y);
            }
            static void Main(string[] args)
            {
                //  int[,] data = ArrayReadConsole();
    
                int[,] data = new int[,]
                {
                    {1,4,6,7,3,5,7,4 },
                    {1,4,5,3,3,5,4,4 },
                    {1,1,6,2,1,5,7,4 },
                    {1,3,6,3,3,5,2,4 },
                    {1,4,6,2,3,5,3,4 },
                    {1,4,2,2,3,5,3,4 },
                    {1,4,3,3,3,5,2,4 },
                    {1,4,4,3,3,5,2,4 }
                };
    
                SumOfPlatform(data);
    
    
               
            }
