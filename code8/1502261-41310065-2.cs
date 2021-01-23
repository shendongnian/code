    public class CustomObject : IComparable
    {
        public string foo { get; set; }
        public string bar{ get; set; }
        public int CompareTo(CustomObject o)
        {
             if (this.foo == o.foo && this.bar == o.bar) return 0;
             //We have to code for the < and > comparisons too.  Could get painful if there are a lot of properties to compare.
             if (this.foo == o.foo) return (this.bar < o.bar);
             return (this.foo < o.foo);
        }
    }
