    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var filename = @"..\..\XMLFile1.xml";
                var model = Read(filename);
            }
    
            private static OrderModel Read(string filename)
            {
                using (var reader = XmlReader.Create(filename))
                {
                    var serializer = new XmlSerializer(typeof(OrderModel));
                    var model = (OrderModel) serializer.Deserialize(reader);
                    return model;
                }
            }
        }
    
        [XmlRoot(ElementName = "order")]
        public class OrderModel
        {
            [XmlElement(ElementName = "purchaser")]
            public CompanyModel Purchaser { get; set; }
    
            [XmlElement(ElementName = "deliverver")]
            public CompanyModel Deliverver { get; set; }
    
            [XmlElement(ElementName = "position")]
            public List<OrderPositionModel> Positions { get; set; }
        }
    
        public class OrderPositionModel
        {
            [XmlAttribute("id")]
            public int id { get; set; }
    
            [XmlAttribute("lp")]
            public int OrdinalNumber { get; set; }
    
            [XmlAttribute("name")]
            public string Name { get; set; }
    
            [XmlAttribute("quantity")]
            public int Quantity { get; set; }
        }
    
        public class CompanyModel
    
        {
            [XmlElement(ElementName = "name")]
            public string Name { get; set; }
    
            [XmlElement(ElementName = "address")]
            public string Address { get; set; }
        }
    }
