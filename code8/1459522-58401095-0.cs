    public class Item
    {
        public string Text { get; }
        public Item (string text)
        {
            this.Text = text;
        }
        public static implicit operator Item[] (Item one) => new[] { one };
    }
    public class Print
    {
        // Accept a params of arrays of items (but also single items because of implicit cast)
        public static void WriteLine(params Item[][] items)
        {
            Console.WriteLine(string.Join(", ", items.SelectMany(x => x)));
        }
    }
    public class Test
    {
        public void Main()
        {
            var array = new[] { new Item("a1"), new Item("a2"), new Item("a3") };
            Print.WriteLine(new Item("one"), /* ... */ array, new Item("two")); 
        }
    }
