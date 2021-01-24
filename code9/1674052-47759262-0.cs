    using System;
    namespace ConsoleInput
    {
    public class TheMiddle
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            
            int result;
            if (a < b)
            {
                if (c < a)
                    result = a;
                else if (c > b)
                    result = b;
                else
                    result = c;
            }
            else
            {
                if (c < b)
                    result = b;
                else if (c > a)
                    result = a;
                else
                    result = c;
            }
            Console.WriteLine(result);
        }
      }
    }
