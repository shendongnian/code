    using System;
    using System.Linq;
    using System.Reflection;
    
    [AttributeUsage(AttributeTargets.All)]
    public class DemoAttribute : Attribute
    {
        public string Property { get; set; }
        public string Ctor1 { get; set; }
        public string Ctor2 { get; set; }
        public string Ctor3 { get; set; }
        
        public DemoAttribute(string ctor1,
                             string ctor2 = "default2", 
                             string ctor3 = "default3")
        {
            Ctor1 = ctor1;
            Ctor2 = ctor2;
            Ctor3 = ctor3;
        }
    }
    
    [Demo("x", ctor3: "y", Property = "z")]
    public class Test
    {
        static void Main()
        {
            var attr = (DemoAttribute) typeof(Test).GetCustomAttributes(typeof(DemoAttribute)).First();
            Console.WriteLine($"Property: {attr.Property}");
            Console.WriteLine($"Ctor1: {attr.Ctor1}");
            Console.WriteLine($"Ctor2: {attr.Ctor2}");
            Console.WriteLine($"Ctor3: {attr.Ctor3}");
        }
    }
