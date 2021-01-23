     public class GeneralModel
    {
        public string Language { get; set; }
    }
    public class AnotherModel
    {
        public string AnotherProperty { get; set; }
    }
    public class SuperClass
    {
        public GeneralModel generalModel { get; set; }
        public AnotherModel anotherModel { get; set; }
    }
