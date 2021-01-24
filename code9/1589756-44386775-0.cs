               int[][] tab = new int[4][];
                tab[0] = new int[4];
                tab[1] = new int[3];
                tab[2] = new int[2];
                tab[3] = new int[1];
    
                int num = 1;
    
                int ai = 0;
                int bj = 0;
    
                while (ai < tab.Length) {
                    bj = 0;
                    while (bj < tab[ai].Length) {
                        tab[ai][bj] = num++;
                        bj++;
                    }
                    ai++;
                }
    
                for (int i = 0; i < tab.Length; i++)
                {
                    Console.Write("tab[{0}] = ", i);
                    for (int j = 0; j < tab[i].Length; j++)
                    {
                        Console.Write("{0} ", tab[i][j]);
                    }
                    Console.WriteLine("");
                }
