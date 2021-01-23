    public interface IInterface
    {
        string X { get; set; }
        string Y { get; set; }
    }
    class A : IInterface
    {
        public string X { get; set; }
        public string Y { get; set; }
        List<B> Z;
    }
    class B : IInterface
    {
        public string X { get; set; }
        public string Y { get; set; }
    }
