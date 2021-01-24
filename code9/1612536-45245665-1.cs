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
            const int A_STRING_CUT_SIZE= 3;
            const int B_STRING_CUT_SIZE = 2;
            public string Merge(string A, string B)
            {
                StringBuilder sb = new StringBuilder();
                int aIndex = 0;
                int bIndex = 0;
                while(aIndex < A.Length / A_STRING_CUT_SIZE && bIndex < B.Length / B_STRING_CUT_SIZE)
                {
                    sb.Append(A.Substring(aIndex * A_STRING_CUT_SIZE, A_STRING_CUT_SIZE) + B.Substring(bIndex * B_STRING_CUT_SIZE, B_STRING_CUT_SIZE));
                    aIndex++;
                    bIndex++;
                }
                return sb.ToString();
            }
        }
    }
