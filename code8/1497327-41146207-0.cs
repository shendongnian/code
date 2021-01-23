    static void F()
    {
        var r = new Random();
        int xMax = 10;
        int yMax = 5;
        int zMax;
        for (int x = 0; x < xMax; x++)
        {
            double xProg = (double)x / xMax;
            for (int y = 0; y < yMax; y++)
            {
                double yProg = (double)y / (yMax * xMax);
                zMax = r.Next(50, 100);
                for (int z = 0; z < zMax; z++)
                {
                    double zProg = (double)z / (zMax * yMax * xMax);
                    var prog = xProg + yProg + zProg;
                    Console.WriteLine(prog.ToString("P"));
                }
            }
        }
        Console.WriteLine(1.ToString("P")); // Make sure to report the final 100%
    }
