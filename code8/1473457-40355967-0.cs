      class Program
    {
        public static int w = 0;
        public static int y = 1;
        static void Main(string[] args)
        {
            int[,] twodimention = new int[10, 10];
            int[] boston = new int[] { 0, 1004, 1753, 2752,3017 ,1520 , 1507, 609, 3155,448 };
            int[] chicago = new int[] { 1004, 0, 921, 1780, 2048, 1397, 919, 515, 2176,709 };
            int[] dallas = new int[] { 1753, 921, 0, 1230, 1399, 1343, 517, 1435,2234,1307 };
            int[] lasVegas = new int[] { 2752, 1708, 1230, 0, 272, 2570, 1732,2251,1322,2420 };
            int[] losAngeles = new int[] { 3017, 2048, 1399, 272,0, 2716,1858,2523,1278,2646 };
            int[] miami = new int[] { 1520, 1397, 1343, 2570, 2716,0,860,1494,3447,1057 };
            int[] newOrleans = new int[] { 1507, 919, 1517, 1732,1858,880,0,1307,2734,1099 };
            int[] toronto = new int[] { 609, 515, 1435,2251,2523,1494,1307,0,2820,571 };
            int[] vancouver = new int[] { 3155,2176,2234,1322,1278,3447,2734,2820,0,2887 };
            int[] washington = new int[] { 448, 709, 1307, 2420, 2646, 1057, 1099, 571, 2887,0 };
            int x = 9;
           
            for (int row = 0; row <= x; row++)
            {
                for (int col = 0; col <=9; col++)
                {
                    if (w == 0)
                    {
                        if (col ==boston.Length - 1 || col < boston.Length - 1)
                        {
                            twodimention[row, col] = boston[col];
                        }
                    }
                    if (w==1)
                    {
                        if(col==chicago.Length-1 || col<chicago.Length - 1)
                        {
                            twodimention[row, col] = chicago[col];
                        }
                    }
                    if (w == 2)
                    {
                        if (col == dallas.Length - 1 || col < dallas.Length - 1)
                        {
                            twodimention[row, col] = dallas[col];
                        }
                    }
                    if (w == 3)
                    {
                        if (col == lasVegas.Length - 1 || col < lasVegas.Length - 1)
                        {
                            twodimention[row, col] = lasVegas[col];
                        }
                    }
                    if (w == 4)
                    {
                        if (col == losAngeles.Length - 1 || col < losAngeles.Length - 1)
                        {
                            twodimention[row, col] = losAngeles[col];
                        }
                    }
                    if (w == 5)
                    {
                        if (col == miami.Length - 1 || col < miami.Length - 1)
                        {
                            twodimention[row, col] = miami[col];
                        }
                    }
                    if (w == 6)
                    {
                        if (col == newOrleans.Length - 1 || col < newOrleans.Length - 1)
                        {
                            twodimention[row, col] = newOrleans[col];
                        }
                    }
                    if (w == 7)
                    {
                        if (col == toronto.Length - 1 || col < toronto.Length - 1)
                        {
                            twodimention[row, col] = toronto[col];
                        }
                    }
                    if (w == 8)
                    {
                        if (col == vancouver.Length - 1 || col < vancouver.Length - 1)
                        {
                            twodimention[row, col] = vancouver[col];
                        }
                    }
                    if (w == 9)
                    {
                        if (col == washington.Length - 1 || col < washington.Length - 1)
                        {
                            twodimention[row, col] = washington[col];
                        }
                    }
                
                }
             
                w = w + 1;
            }
            Console.WriteLine();
            for (int row = 0; row <= x; row++)
            {
                for (int col = 0; col <= 9; col++)
                {
               Console.Write(twodimention[row, col]+"\t");
                   
                }
              
            }
        }
    }
