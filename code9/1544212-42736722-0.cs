    namespace ConsoleApplication6
    {
    
        class Formation
        {
            public int x;
            public int y;
    
            public Formation(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
    
    
            public void form()
            {
                int r = x / y;
                int Left = x % y;
                int Space = (y - Left)/2;
                for (int i = 0; i < r;i++)
                    {
                    for (int j = 0; j < y; j++)
                        {
                        Console.Write("A");
                        }
                    Console.WriteLine();
                    if (i == r - 1)
                    {
                        for (int m = 0; m < Space; m++)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 0; k < Left; k++)
                        {
                            Console.Write("A");
                        }
                    }
                    }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                
                Console.WriteLine("enter the number of men: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the formation width: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Formation testudo = new Formation(a,b);
                testudo.form();
                Console.ReadKey();
            }
        }
    }
