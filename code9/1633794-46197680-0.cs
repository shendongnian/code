    Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter m: ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,m];
            int row = 0;
            int col = 0;
            string direction = "right";
            int maxRotations = n * m;
            for (int i = 1; i <= maxRotations; i++)
            {
                if (direction == "right" && (col > m - 1 || matrix[row, col] != 0))
                {
                    direction = "down";
                    col--;
                    row++;
                }
                if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
                {
                    direction = "left";
                    row--;
                    col--;
                }
                if (direction == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "up";
                    col++;
                    row--;
                }
                if (direction == "up" && row < 0 || matrix[row, col] != 0)
                {
                    direction = "right";
                    row++;
                    col++;
                }
                matrix[row, col] = i;
                if (direction == "right")
                {
                    col++;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "up")
                {
                    row--;
                }
            }
            // displej matrica
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m ; c++)
                {
                    Console.Write("{0,4}", matrix[r,c]);
                }
                Console.WriteLine();
                
            }
            Console.ReadLine();
        }
