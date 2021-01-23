        public static void Main(string[] args)
        {
            string xmlString = "<Products><Product><Id>1</Id><Name>My XML product</Name></Product><Product><Id>2</Id><Name>My second product</Name></Product></Products>";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
            List<Product> productList = new List<Product>();
            using (StringReader stringReader = new StringReader(xmlString))
            using (XmlReader xmlReader = XmlReader.Create(stringReader))
            {
                xmlReader.ReadToDescendant("Products");
                productList = (List<Product>)serializer.Deserialize(xmlReader.ReadSubtree());
            }
        }
