    namespace ConsoleApplication3
    {
        using System.Collections.Generic;
        using System.Linq;
        using ClassLibrary1;
    
        public class Program
        {
            private static void Main(string[] args)
            {
                // NOTE: You can't cast the structs to IWriter here.
                var structs = Worker.DoSomething();
                // This will not compile:
                // (structs.FirstOrDefault() as IWriter).Property1 = 10
            }
        }
    }
