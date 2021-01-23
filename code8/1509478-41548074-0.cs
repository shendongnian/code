    using System;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                int[,] array = new int[,]
                {
                    {  95,  50 },
                    {  77,  78 },
                    {  52, 100 },
                    { 100,  73 },
                    {  86,  77 },
                    {  99,  50 }
                };
    
                for (int i = 0; i <= array.GetUpperBound(0); i++)
                {
                    float i1 = array[i, 0];
                    float i2 = array[i, 1];
    
                    var calc = i2 / i1;
    
                    if ( calc < 0.70 )
                    {
                        Console.WriteLine("{0} negative", calc);
                    }
                    else if ( calc > 1.3 )
                    {
                        Console.WriteLine("{0} positive", calc);
                    }
                    else
                    {
                        Console.WriteLine("{0} ignore", calc);
                    }
                }
    
                Console.ReadKey();
            }
        }
    }
    
