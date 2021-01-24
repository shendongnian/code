    public class MyClass : IEquatable<MyClass>
    {
        public string ID { get; set; }
        public myEnum CallType { get; set; }
        public object ObjToStore { get; set; }
        public bool Equals(MyClass x)
        {
            return x.ID.Equals(this.ID);
        }
    }
