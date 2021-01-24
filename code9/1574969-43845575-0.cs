    public interface ISomething {
        string MyProperty { get; set; }
        int AnotherProperty { get; set; }
        
        B ClassProperty { get; set; }
    }
    public class A : ISomething {
        public string MyProperty { get; set; }
        public int AnotherProperty { get; set; }
        public B ClassProperty { get; set; }
    }
    public class B {
        public string BProperty_1 { get; set; }
        public int BProperty_2 { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            // Configure the mapping
            Mapper.Initialize(cfg => cfg.CreateMap<ISomething, ISomething>());
            // Initialize first instance
            var firstA = new A {
                MyProperty = "Test",
                AnotherProperty = 21,
                ClassProperty = new B {
                    BProperty_1 = "B String",
                    BProperty_2 = 555
                }
            };
            // Initialize second instance and perform the mapping
            var secondA = Mapper.Map<ISomething>(firstA);
