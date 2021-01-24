        using System;
        using System.Xml.Serialization;
        using System.Collections.Generic;
        namespace classes
        {
        	[XmlType(Namespace = "urn:ebay:apis:eBLBaseComponents")]
       public class Order
        {
            public string OrderID { get; set; }
            public string OrderStatus { get; set; }
        }
    
        [XmlType(Namespace = "urn:ebay:apis:eBLBaseComponents")]
        public class OrderArray
        {
            public Order Order { get; set; }
        }
    
        [XmlRoot(Namespace = "urn:ebay:apis:eBLBaseComponents")]
        public class GetOrdersResponse
        {
            public string Timestamp { get; set; }
            public string Ack { get; set; }
            public string Version { get; set; }
            public string Build { get; set; }
            public OrderArray OrderArray { get; set; }
        }
        
        }
