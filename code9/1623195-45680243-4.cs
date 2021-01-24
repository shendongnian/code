    using System;
    
    class Test
    {
        static void Main()
        {
            float f = 4.9999994f;
            
            Console.WriteLine(f);
            Console.WriteLine(f == 5f);
            Console.WriteLine(Math.Floor(f));
            // Roundtrip format
            Console.WriteLine(f.ToString("r"));
            // My own code to print binary floating point values precisely
            Console.WriteLine(DoubleConverter.ToExactString(f));
        }
    }
