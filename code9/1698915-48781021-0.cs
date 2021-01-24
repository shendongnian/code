    static void Main(string[] args)
        {
            int x, y, z;
            Console.Write("enter row number :");
            y = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter col number :");
            z = Convert.ToInt32(Console.ReadLine());
            for (x = 1; x <= y; x++)
            {
                Console.Write(" " + "@"); 
            
            }
            Console.WriteLine("\n");
            for (x = 1; x <= z; x++)
            {
                Console.WriteLine( "@"); ;
            }
            Console.ReadKey();
        }
