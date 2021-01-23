    class Program
    {
        static void Main(string[] args)
        {
            char[][] arr = new char[numberofline][];
    
            string[] lines = File.ReadAllLines("read.txt");
    
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    arr[i][j] = lines[i][j];
                }
            }
            Console.WriteLine("press any key to close console.");
        }
    }
