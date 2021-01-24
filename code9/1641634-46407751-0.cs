    public interface AandB
    {
        string Name { get; set; }
    }
    public class A : AandB
    {
            
        public string Name { get; set; }
        public string id { get; set; }
    }
    class B : AandB
    {
        public string Name { get; set; }
        public string id { get; set; }
    }
