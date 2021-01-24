    interface IMyInterface
    {
        string GetMessage();
    }
    
    class ThingWithMessage : IMyInterface
    {
        public string GetMessage()
        {
            return "yes, this works.";
        }
    }
    ...
    using System;
    class Program
    {
        static void Main()
        {
            IMyInterface thing = new ThingWithMessage();
            Console.WriteLine(thing.GetMessage());
            Console.ReadKey();
        }    
    }
    
