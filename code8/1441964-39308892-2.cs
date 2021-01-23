    using System;
    
    public class Test
    {
        public static int addNumbers(int num1, int num2) 
       {
        int result;
        result = num1 + num2;
        return result;
        }
    
        public static void Main()
        {
            int a = 2;
            int b = 2;
            int r;
    
            
            r = addNumbers(a, b);
    
            Console.WriteLine(r);
        }
    }
