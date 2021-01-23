    //Reference where I got all this:
    //https://support.microsoft.com/en-us/kb/828736
    
    // Class1.cs
    // A simple managed DLL that contains a method to add two numbers.
    using System;
    using System.Runtime.InteropServices;
    
    
    namespace ManagedDLL
    {
        // Interface declaration.
        public interface ICalculator
        {
            //Test functions
            int Add(int Number1, int Number2);
            int ReturnAge();
            string StringTest();
            void PrintAString([MarshalAs(UnmanagedType.BStr)] string stringToPrint);
        };
    
        // Interface implementation.
        public class ManagedClass : ICalculator
        {
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //Test functions
            public int Add(int Number1, int Number2)
            {
                return Number1 + Number2;
            }
    
            public int ReturnAge()
            {
                return 35;
            }
    
            public string StringTest()
            {
                return "Can you hear me now?";
            }
    
            public void PrintAString([MarshalAs(UnmanagedType.BStr)] string stringToPrint)
            {
                Console.WriteLine("Trying to print a BSTR in C#");
               
                Console.WriteLine(stringToPrint);
                Console.WriteLine("Done printing");
            }
        }
    }
