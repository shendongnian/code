    using System;
    
    namespace LanguageFeatures.Models
    {
        public class Product
        {
            //field
            private string name;
    
            //property
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
    
            public int Test { get; set; }
    
        }
        public class TestProperty
        {
            //constructor
            public TestProperty()
            {
                Product p = new Product { Name = "asd", Test = 1 };
                Console.WriteLine(p.Test.ToString());
            }
        }
    }
