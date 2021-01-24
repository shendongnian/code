    public class Person
    {
        private XDocument xml;
    
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        [NotMapped]
        public int Age
        {
            get
            {
                return int.Parse(xml.Element("Properties").Element("Age").Value);
            }
            set
            {
                xml.Element("Properties").Element("Age").Value = value.ToString();
            }
        }
                    
        [Column(TypeName = "xml")]
        public string DataXML
        {
            get
            {
                return xml.ToString();
            }
            set
            {
                xml = XDocument.Parse(value);
            }
        }
    }
