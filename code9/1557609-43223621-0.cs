            double bx, by;
            double[,] array = new double[,]
            {
            {200,-400},
            {300,-6000},
            {400,-125},
            {100,-120}
            };
            for (var i = 0; i < 4; i++)
            {
                Console.Write($"({array[i, 0]}, {array[i, 1]})");
            }
            for (int x = 0; x < 3; x++)
            {
                bx = array[x, 0];
                by = array[x, 1];
                array[x, 0] = array[x + 1, 0];
                array[x, 1] = array[x + 1, 1];
                array[x + 1, 0] = bx;
                array[x + 1, 1] = by;
                Console.WriteLine();
                for (var i = 0; i < 4; i++)
                {
                    Console.Write($"({array[i, 0]}, {array[i, 1]})");
                }
            }
            Console.ReadKey();
