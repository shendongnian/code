            public static int test(int? n) // without the keyword ref
            {
                int x = 10;
                //n = 5; // Why was that??
                if (n != null)
                {
                    Console.WriteLine("not null");
                    n = x;
                    return 0;
                }
                Console.WriteLine("is null");
                return 1;
            }
    
            static void Main(string[] args)
            {
    
                int? i = null; // nullable int
                int? j = 100; // nullable to math the parameter type
                test(i);
                test(j);
                Console.WriteLine(i);
            }
