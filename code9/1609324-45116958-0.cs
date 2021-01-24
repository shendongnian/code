    using System;
    using System.Linq;
    
    public class Test
    {
	    public static void Main()
            {
                var w = 10;
                var h = 5;
                Console.WriteLine(String.Join("", Enumerable.Repeat(String.Join("", Enumerable.Repeat("*", w)) + "\n", h)));
            }
    }
