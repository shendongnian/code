    using System;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine(M());
        }
    
        static int M()
        {
            int dummy = 0;
            for (int a = 0; a < 10; a++)
            {
                for (int y = 0; y < 10; y++) // Run until condition.
                {
                    for (int x = 0; x < 10; x++) // Run until condition.
                    {
                        if (x == 5 &&
                            y == 5)
                        {
                            goto Outer;
                        }
                    }
                    dummy++;
                }
            Outer:
                continue;
            }
            return dummy;
        }
    }
