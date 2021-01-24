        int w = Console.WindowWidth;
        int h = Console.WindowHeight;
        int i = 0;
        while (i < h)
        {
            int j = 0;
            Thread.Sleep(14);
            while (j < w)
            {
                Console.SetCursorPosition(j, i);
                Console.Write(".");
                j++;
            }
            Console.WriteLine(s);
            i++;
        }
