    using System;
    using System.Text;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Thing t = new Thing();
                Console.WriteLine(t.Merge("Hellooooooo", "Worldddddddddddd"));
                Console.ReadLine();
            }
        }
    
        public class Thing
        {
            public string Merge(string A, string B)
            {
                StringBuilder sb = new StringBuilder();
                int aIndex = 0;
                int bIndex = 0;
                while(aIndex < A.Length / 3 && bIndex < B.Length / 3)
                {
                    sb.Append(A.Substring(aIndex * 3, 3) + B.Substring(bIndex * 2, 2));
                    aIndex++;
                    bIndex++;
                }
                return sb.ToString();
            }
        }
    
    
    }
