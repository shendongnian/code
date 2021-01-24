    public class Foo
    {
        public int value1 { get; set; }
    
        public string ToXML()
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(stringwriter, this);
            return stringwriter.ToString();
        }
    
        // You have to use your Class-Type here 3 times
        public static Foo LoadFromXML(string filePath)
        {
            using (StreamReader streamReader = new System.IO.StreamReader(filePath))
            {
                var serializer = new XmlSerializer(typeof(Foo));
                return serializer.Deserialize(streamReader) as Foo;
            }
        }
    }
