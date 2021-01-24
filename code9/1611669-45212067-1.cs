    using System;
    
    public class Container
    {
        public Item Item { get; set; } = new Item();
    }
    
    public class Item
    {
        public string Value { get; set; }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            var container = new Container
            {
                Item = { Value = "hello" }
            };
        }
    }
