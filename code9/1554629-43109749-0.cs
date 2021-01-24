    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace classes
    {
    	[XmlRoot(ElementName="Order", Namespace="urn:ebay:apis:eBLBaseComponents")]
    	public class Order {
    		[XmlElement(ElementName="OrderID", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public string OrderID { get; set; }
    		[XmlElement(ElementName="OrderStatus", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public string OrderStatus { get; set; }
    	}
    
    	[XmlRoot(ElementName="OrderArray", Namespace="urn:ebay:apis:eBLBaseComponents")]
    	public class OrderArray {
    		[XmlElement(ElementName="Order", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public Order Order { get; set; }
    	}
    
    	[XmlRoot(ElementName="GetOrdersResponse", Namespace="urn:ebay:apis:eBLBaseComponents")]
    	public class GetOrdersResponse {
    		[XmlElement(ElementName="Timestamp", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public string Timestamp { get; set; }
    		[XmlElement(ElementName="Ack", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public string Ack { get; set; }
    		[XmlElement(ElementName="Version", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public string Version { get; set; }
    		[XmlElement(ElementName="Build", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public string Build { get; set; }
    		[XmlElement(ElementName="OrderArray", Namespace="urn:ebay:apis:eBLBaseComponents")]
    		public OrderArray OrderArray { get; set; }
    		[XmlAttribute(AttributeName="xmlns")]
    		public string Xmlns { get; set; }
    	}
    
    }
