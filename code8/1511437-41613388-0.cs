    using System;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                var condensed1 = new Condensed() { FilePath = "/filepath1/" };
                var condensed2 = new Condensed() { FilePath = "/filepath2/blah/" };
                var condensed3 = new Condensed() { FilePath = "/filepath3/blah/blah/" };
    
                Console.WriteLine(condensed1.FilePath);
                Console.WriteLine(condensed2.FilePath);
                Console.WriteLine(condensed3.FilePath);
    
                Console.ReadKey();
            }
        }
    
        public partial class Condensed
        {
            public string FilePath { get; set; }
        }
    }
    
