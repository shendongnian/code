    public class CustomObject : IComparable
    {
        public string foo { get; set; }
        public string bar{ get; set; }
        public int CompareTo(CustomObject o)
        {
             return (this.foo != o.foo || this.bar != o.bar);
        }
    }
