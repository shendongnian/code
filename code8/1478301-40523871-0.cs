    class Program
    {
        static void Main(string[] args)
        {
            // read your xml from somewhere
            var xml = File.ReadAllText("Address.xml");
            XDocument xmldoc = XDocument.Parse(xml);
            // get the element by id
            var element = GetElementById(xmldoc, 1);
            // deserialize element
            var xmlSerializer = new XmlSerializer(typeof(Person));
            var person = (Person)xmlSerializer.Deserialize(element.CreateReader());
            // continue to work with person
        }
        private static XElement GetElementById(XDocument xmldoc, string id)
        {
            // Elements according to your XML file
            var element = xmldoc.Element("Address")
                .Elements("Data2")
                .Elements("Person")
                .Single(x => x.Element("ID_NUM").Value == id);
            return element;
        }
    }
    
    /// <summary>
    /// Used for deserialization
    /// </summary>
    public class Person
    {
        public int EMPL_NUM { get; set; }
        public string NAME { get; set; }
        public int ID_NUM { get; set; }
        public bool IsRequired { get; set; }
    }
