    public class MyClass : IEqualityComparer<MyClass>
    {
        public string ID { get; set; }
        public myEnum CallType { get; set; }
        public object ObjToStore { get; set; }
        public bool Equals(MyClass x, MyClass y)
        {
            return x.ID.Equals(y.ID);
        }
        public int GetHashCode(MyClass obj)
        {
            return obj.ID.GetHashCode();
        }
    }
