    using System;
    
    public delegate int Int32Operation(int x, int y);
    
    class Program
    {
        public static int AddNumbers(int x, int y)
        {
            return x + y;
        }
        
        public static int SubtractNumbers(int x, int y)
        {
            return x - y;
        }
        
        static void Main(string[] args)
        {
            Int32Operation op = new Int32Operation(AddNumbers);
            Console.WriteLine(op(3, 4)); // Prints 7
            
            op = SubtractNumbers; // Method group conversion
    
            Console.WriteLine(op(3, 4)); // Prints -1
        }
    }
