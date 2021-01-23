    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication2
    {
        public static class Files
        {
            public const string FileA = "Block1";
            public const string FileB = "Block2";
            public const string FileC = "Block3";
            public const string FileD = "Block6.Block7";
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var t = typeof(Files);
                var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
    
                var list = fields.Select(x => new {Field = x.Name, Value = x.GetValue(null).ToString()});
    
    
                Console.Read();
            }
        }
    }
