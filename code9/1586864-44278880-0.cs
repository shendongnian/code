        [XmlRoot]
        [Serializable]
        public class SalesInvoice
        {
            [XmlElement]
            public List<Detail> Details { get; set; }
    
            public SalesInvoice()
            {
                Details = new List<Detail>();
            }
        }
    
        [Serializable]
        public class Detail
        {
            [XmlElement]
            public string Product { get; set; }
    
            [XmlElement]
            public string Quantity { get; set; }
        }
