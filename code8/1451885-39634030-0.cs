    using System.Collections.Generic;
    using System.Linq;
    using static System.Console;
    
    class Methods {
        public static void M(int x)     {
            // no-op
        }
    
        public static void M<T>(IEnumerable<T> x)     {
            // no-op
        }
    }
    
    class Program {
        static void Main(string[] args)  {
            Methods.M(0);
            Methods.M(new[] { "a", "b" });
    
            ShowAllM();
        }
    
        public static void ShowAllM() {
            var tm = typeof(Methods);
            foreach (var mi in tm.GetMethods().Where(m => m.Name == "M"))
            {
                WriteLine(mi.Name);
                foreach (var p in mi.GetParameters())
                {
                    WriteLine($"\t{p.ParameterType.Name}");
                }
            }
        }
    }
