    public class A
    {
        public A(String s)
        {
            SA = s;
        }
        public String SA { get; set; }
    }
    public class B : A
    {
        public B(String s, string s1)
        {
            SA = s;
            SB = s1;
        }
        public String SB { get; set; }
    }
    class Stack<T>
    {
        Stack<U> FilteredStack<U>() where U : T
        {
            return new Stack<U>(Items.OfType<U>());
        }
        public IEnumerable<T> Items { get { return _items; } }
        public static void Test()
        {
            var s1 = new Stack<A>(new[] { new A("A1"), new B("B1", "Some other value") });
            var s2 = s1.FilteredStack<B>();
            //  s2 is a strongly typed stack of type B
            Console.WriteLine(s2.Items.First().SB);
        }
        private List<T> _items = new List<T>();
        public Stack(IEnumerable<T> items) {
            _items = new List<T>(items);
        }
    }
