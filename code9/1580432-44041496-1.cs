    internal class Program
        {
            private static void Main()
            {
                var gi = new GroceryItem("Carrot");
                gi.Foo();
    
                Console.WriteLine(gi.Description);
            }
        }
    
        internal class GroceryItem
        {
            public GroceryItem(string description)
            {
                Description = description;   // We can set this in ctor
            }
            public string Description { get; protected set; }
    
            public void Foo()
            {
                Description = "Foo";
            }
        }
