    public class A
    {
        // no 'virtual' here
        public string Value { get; set; }
    }
    public class B : A
    {
        public new int Value { get; set; }
    }
