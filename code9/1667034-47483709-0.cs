    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main (string[] args)
            {
                var str = "4ADA6CA9C2D571EF6E2A8CC3C94D36B9";
                var result = Partition (str, 2).ToArray ();
            }
            public static IEnumerable<string> Partition (string str, int partSize)
            {
                if (str == null) throw new ArgumentNullException ();
                if (partSize < 1) throw new ArgumentOutOfRangeException ();
                var sb = new StringBuilder (partSize);
                for (int i = 0; i < str.Length; i++) 
                {
                    sb.Append (str[i]);
                    bool isLastChar = i == str.Length - 1;
                    if (sb.Length == partSize || isLastChar)
                    {
                        yield return sb.ToString ();
                        sb.Clear ();
                    }
                }
            }
        }
    }
