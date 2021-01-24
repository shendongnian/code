    using System;
    
    class stringReplace1
    {
        public static void Main()
        {
            String str = "T3123123";
    
            Console.WriteLine("Original string: \"{0}\"", str);
    
            str = str.Insert(1, " ");
    
            Console.WriteLine(str);
    
            Console.ReadKey();
        }
