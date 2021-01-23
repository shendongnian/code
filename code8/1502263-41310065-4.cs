    public class CustomObject : IComparable
    {
        public string foo { get; set; }
        public string bar{ get; set; }
        public int CompareTo(CustomObject o)
        {
             if (this.foo == o.foo && this.bar == o.bar) return 0;
             //We have to code for the < and > comparisons too.  Could get painful if there are a lot of properties to compare.
             if (this.Foo == o.Foo) return (this.Bar.CompareTo(o.Bar));
             return this.Foo.CompareTo(o.Foo);
        }
    }
