    public class Cargo
    {
        [XmlAttribute]
        public int Id { get; set; }
        
        [XmlAttribute]
        public string Name { get; set; }
    }
    [XmlRoot("A")]
    public class A : List<Cargo>
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(A));
            var subReq = new A { new Cargo { Id = 3, Name = "test" }, new Cargo { Id = 4, Name = "foo" } };
            var xml = "";
            using (StringWriter sww = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                xsSubmit.Serialize(writer, subReq);
                xml = sww.ToString(); // Your XML
            }
        }
    }
