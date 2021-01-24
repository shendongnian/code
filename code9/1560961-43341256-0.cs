            for (int x = 0; x < lottoNumbers.GetLength(0); x++)
            {
                Console.Write("Game" + lottoNumbers[x, 0] + "\t");
                for (int y = 0; y < lottoNumbers.GetLength(1); y++)
                {
                    Console.Write($"{lottoNumbers[x, y],2}" + "\t");
                }
                Console.WriteLine();
            }
