    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            public static FileStream fs = new FileStream("C:/Test/SpanningTree.txt", FileMode.Append,
                FileAccess.Write);
    
            public static void Print(StreamWriter sw, int level)
            {
    
                sw.WriteLine("----------------------------------------------------------------------------------------");
                sw.WriteLine("{0} Level : '{1}' ", new string(' ', 4 * level), level);
                sw.WriteLine("----------------------------------------------------------------------------------------");
    
                if (level < 10)
                {
                    Print(level + 1);
                }
            }
    
            private static void Main(string[] args)
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
    
                    Print(1);
                }
            }
        }
    
    }
