    Cell[,] Points = new Cell[Console.WindowHeight, Console.WindowWidth];
        for(int i = 0; i < Console.WindowHeight; i++)
        {
            for(int j = 0; j < Console.WindowWidth; j++)
            {
                bool Alive = false;
                if (rnd.Next(0, 10) == 1)
                    Alive = true;
                Cell cell = new Cell(i, j, Alive);
                Points[i, j] = cell; //this is missing
            }
        }
