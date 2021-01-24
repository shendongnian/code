    namespace ConsoleApplication3
    {
        using System.Collections.Generic;
        using System.Linq;
        using ClassLibrary1;
    
        public class Program
        {
            private static void Main(string[] args)
            {
                // NOTE: You COULD cast the structs to IWriter here.
                var structs = Worker.DoSomething();
            }
        }
    }
