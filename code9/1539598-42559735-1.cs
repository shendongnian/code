    static public void Rec(int x, int y, int counter)
        {
            if (mas[x, y] == 0)
            {
                counter++;
                mas[x, y] = counter;
                if (x - 1 >= 0)
                {
                    Rec(x - 1, y, counter);
                    if (y - 1 >= 0)
                        Rec(x - 1, y - 1, counter);
                }
                if (y - 1 >= 0)
                {
                    Rec(x, y - 1, counter);
                    if (x + 1 <= maxx)
                    {
                        Rec(x + 1, y - 1, counter);
                    }
                }
                if (x + 1 <= maxx)
                {
                    Rec(x + 1, y, counter);
                    if (y + 1 <= maxy)
                    {
                        Rec(x + 1, y + 1, counter);
                    }
                }
                if (y + 1 <= maxy)
                {
                    Rec(x, y + 1, counter);
                    if (x - 1 >= 0)
                    {
                        Rec(x - 1, y + 1, counter);
                    }
                }
            }
        }
