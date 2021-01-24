    public class MyCollection
    {
        public List<Employee> = new List<Employee>();
        public List<Department> = new List<Department>();
        public List<Address> = new List<Address>();
        public string ToXML()
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(this.GetType());
            serializer.Serialize(stringwriter, this);
            return stringwriter.ToString();
        }
    
        // You have to use your Class-Type here 3 times
        public static MyCollection LoadFromXML(string filePath)
        {
            using (StreamReader streamReader = new System.IO.StreamReader(filePath))
            {
                var serializer = new XmlSerializer(typeof(MyCollection));
                return serializer.Deserialize(streamReader) as MyCollection;
            }
        }
    }
