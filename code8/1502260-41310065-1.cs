    public class CustomObject : IComparable
    {
        public string foo { get; set; }
        public string bar{ get; set; }
        public int CompareTo(CustomObject o)
        {
             if (this.foo == o.foo || this.bar == o.bar) return 0;
             return 1; //Hmmm....
        }
    }
