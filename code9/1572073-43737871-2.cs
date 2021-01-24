    public class MyClass : IEquatable<MyClass>
    {
        public string ID { get; set; }
        public myEnum CallType { get; set; }
        public object ObjToStore { get; set; }
        public bool Equals(MyClass other)
        {
            return other != null && other.ID == this.ID;
        }
    }
