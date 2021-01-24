    public class Attribute
    {
        public string ePCode { get; set; }
    }
    public class Container
    {
        public string ccCode { get; set; }
        public List<Attribute> attributes { get; set; }
    }
    public class ValueContainer
    {
        public List<Container> value { get; set; }
    }
