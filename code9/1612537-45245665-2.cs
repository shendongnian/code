     using System;
    using System.Text;
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thing t = new Thing();
                Console.WriteLine(t.Merge("123,456,789", "11,22,33"));
                Console.ReadLine();
            }
        }
        /// <summary>
        /// The incredible THING
        /// </summary>
        public class Thing
        {
            //overly fancy consts
            const int A_STRING_CUT_SIZE = 3;
            const int B_STRING_CUT_SIZE = 2;
            /// <summary>
            /// Merges two codes together
            /// </summary>
            /// <param name="A">The first code</param>
            /// <param name="B">The second code</param>
            /// <returns></returns>
            public string Merge(string A, string B)
            {
                //strip 'em
                string aCopy = A.Replace(",", "");
                string bCopy = B.Replace(",", "");
                //prep' 'em
                StringBuilder sb = new StringBuilder();
                int aIndex = 0;
                int bIndex = 0;
                //loop 'em
                while (aIndex < aCopy.Length / A_STRING_CUT_SIZE && bIndex < bCopy.Length / B_STRING_CUT_SIZE)
                {
                    //build 'em
                    sb.Append(aCopy.Substring(aIndex * A_STRING_CUT_SIZE, A_STRING_CUT_SIZE));
                    sb.Append(bCopy.Substring(bIndex * B_STRING_CUT_SIZE, B_STRING_CUT_SIZE));
                    sb.Append(",");
                    //increment 'em
                    aIndex++;
                    bIndex++;
                }
                //clean 'em
                sb.Remove(sb.Length - 1, 1);
                //send 'em back
                return sb.ToString();
            }
        }
    }
