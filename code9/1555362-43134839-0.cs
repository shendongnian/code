    [XmlRoot]
    public class EMAIL
    {
        [XmlElement("ADDR")]
        public ADDR ADDR { get; set; }
        [XmlElement("BODY")]
        public string BODY { get; set; }
    }
    public class ADDR
    {
        [XmlAttribute("To")]
        public string To { get; set; }
        [XmlAttribute("Sub")]
        public string Sub { get; set; }
    }
    static void Main(string[] args)
    {            
            var fileName = @"your xml file here";
            var xmlResult = System.IO.File.ReadAllText(fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(EMAIL));
            using (TextReader reader = new StringReader(xmlResult))
            {
                EMAIL result = (EMAIL)serializer.Deserialize(reader);
                Console.WriteLine(result.ADDR.Sub);
                Console.WriteLine(result.ADDR.To);
                Console.WriteLine(result.BODY);
            }
           
            Console.Read();
    }
