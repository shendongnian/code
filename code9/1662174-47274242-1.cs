    public class ListClass
    {
        public WrapperList List { get; set; }
    }
    public class WrapperList
    {
        public WrapperA A { get; set; }
        public WrapperB B { get; set; }
    }
    public class WrapperA
    {
        public ClassA ClassA { get; set; }
    }
    public class WrapperB
    {
        public ClassB ClassB { get; set; }
    }
    public class ClassA : IInterface
    {
        public String PropertyA { get; set; }
    }
    public class ClassB : IInterface
    {
        public String PropertyB { get; set; }
    }
