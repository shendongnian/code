        int w = Console.WindowWidth;
        int h = Console.WindowHeight;
        int i = 0;
        while (i < h)
        {
            int j = 0;
            string s = "";
            Thread.Sleep(10);
            while (j < w)
            {
                Console.SetCursorPosition(j, i);
                s += ".";
                j++;
            }
            Console.Write(s);
            i++;
        }
