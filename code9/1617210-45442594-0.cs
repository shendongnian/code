    class Program
    {
        static void Main(string[] args)
        {
            var props = typeof(Foo).GetProperties();
            var filtered = props.Where(x => x.GetCustomAttributes(typeof(FirstAttribute), false).Length > 0).ToList();
        }
    }
    class Foo
    {
        [First]
        public string SomeString { get; set; }
        [First(SomeFlag = true)]
        public int SomeInt { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property)]
    class FirstAttribute : Attribute
    {
        public bool SomeFlag { get; set; }
    }
