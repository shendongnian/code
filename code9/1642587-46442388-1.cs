    public static T Deserialize<T>(string xmlText)
    {
        try
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
        catch
        {
            throw;
        }
    }
    [XmlElement("adress")]
    public class Adress
    {
        [XmlElementAttribute("street_address")]
        public string street_address { get; set; }
    
        [XmlElementAttribute("postal_code")]
        public string postal_code { get; set; }
    
        [XmlElementAttribute("city")]
        public string city { get; set; }
    
        [XmlElementAttribute("country")]
        public string country { get; set; }
    }
    public main()
    {
         Adress myAdress = Deserialize<Adress>(XMLstring);
    }
