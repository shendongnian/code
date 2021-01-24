    using System;
    using System.Text;
    using System.Globalization;
    
    namespace StackOverflow {
        class Program {
            public static void Main(string[] args) {
                var s = ", Ṣur";
                // Len == 11
                Console.WriteLine("{0}: {1}", s, s.Length);
    
                // len == 8
                var si = new StringInfo(s);
                Console.WriteLine("{0}: {1}", s, si.LengthInTextElements);
            }
        }
    }
