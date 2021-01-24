    namespace Program
    {    
    
    public class Castles
    {
        private int xMe;
    
        private int yMe;
    
        private int zMe;
    
        private int xEn;
    
        private int yEn;
    
        private int zEn;
    
        private int dif = 0;
        public static string Process(uint[,] grid)
        {
            int taxX = 0;
            int taxY = 0;
    
            for (int i = 0; i < grid.GetLength; i++)
            {
                for(int j = 0; j < grid[i]; j++)
                {
                    for(int k = 0; k < grid.GetLength; k++)
                    {
                        for(int l = 0; l < grid[k]; l++)
                        {
                            if (distance(i, j, k, l) > 3)
                            {
                                if (grid[i, j] != 0 && grid[k, l] != 0)
                                {
                                for (int m = 0; grid.GetLength; m++)
                                {
                                    for (int n = 0; grid[m]; n++)
                                    {
                                        if (grid[i, j] != grid[m, n] || grid[k, l] != grid[m, n])
                                        {
                                                if(distance(i,j,m,n) > distance(m, n, k, l))
                                                {
                                                    taxX = taxX + distance[m, n];
                                                }
                                                else if(distance(i,j,m,n)< distance(m, n, k, l))
                                                {
                                                    taxY = taxY + distance[m, n];
                                                }
                                                else
                                                {
    
                                                }
                                        }
                                    }
                                }
                                if(taxX - taxY > dif)
                                    {
                                        xMe = i;
                                        yMe = j;
                                        xEn = k;
                                        yEn = l;
                                        zMe = taxX;
                                        zEn = taxY;
                                        dif = taxX - taxY;
                                    }
                            }
                            }
                        }
                    }
                }
            }
    
            return "Your castle at (" + xMe + "," + yMe + ") earns " + zMe + ". Your nemesis' castle at (" + xEn + "," + yEn + ") earns " + zEn + ".";
        }
    
        public int distance(int x, int y, int a, int b)
        {
            int c = a - x;
            int d = b - y;
            return Math.Sqrt(c ^ 2 + d ^ 2);
        }
    
        static void Main(string[] args)
        {
            System.Console.WriteLine("");
        }
    }
