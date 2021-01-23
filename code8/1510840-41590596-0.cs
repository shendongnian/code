    using System;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                var stringImplicit = "Blah";
                string stringExplicit = "Blah";
    
                Console.WriteLine("IMPLICIT : {0} - {1}", stringImplicit, stringImplicit.GetType().Name);
                Console.WriteLine("EXPLICIT : {0} - {1}", stringExplicit, stringExplicit.GetType().Name);
    
                Console.ReadKey();
            }
        }
    }
