    public class Class1
    {
        public Dictionary<string, Class2> ClassTwos { get; private set;}
        public Class1()
        {
            ClassTwos = new Dictionary<string, Class2>();
        }
    }
    public class Class2 {}
