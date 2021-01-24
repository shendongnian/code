            double[,] multiplicationTable = new double[4, 4];
            for (int i = 0; i < multiplicationTable.GetLength(0); i++)
            {
                for (int j = 0; j < multiplicationTable.GetLength(1); j++)
                {
                    multiplicationTable[i, j] = i * j;
                    double d = multiplicationTable[i, j];
                    if (j < multiplicationTable.GetLength(1) - 1)
                    {
                        Console.Write(d + ",");
                    }
                    else
                    {
                        Console.Write(d);
                    }
                }
                Console.Write("\n");
            }
            Console.ReadKey();
