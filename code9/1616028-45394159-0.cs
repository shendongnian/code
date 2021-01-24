    using System;
    public class ContainsStaticVariable
    {
        public static string ExampleStaticVariable = "I am the value of a static variable";
    }
    public class DisplayContentsOfStaticVariable
    {
        public static void Main()
        {
            Console.WriteLine(ContainsStaticVariable.ExampleStaticVariable);
            Console.WriteLine("Press return to exit...");
            Console.ReadLine();
        }
    }
