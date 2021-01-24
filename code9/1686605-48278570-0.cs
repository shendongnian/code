    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace YourAppNameSpace
    {
    	[XmlRoot(ElementName="CabinetList")]
    	public class InventoryDM {
    		[XmlElement(ElementName="InventoryID")]
    		public string InventoryID { get; set; }
    	}
    
    	[XmlRoot(ElementName="Product")]
    	public class Product {
    		[XmlElement(ElementName="ProductID")]
    		public int? ProductID { get; set; }
    		[XmlElement(ElementName="Cost")]
    		public Decimal Cost { get; set; }
    		[XmlElement(ElementName="UPC")]
    		public string UPC { get; set; }
    		[XmlElement(ElementName="TaxStatus")]
    		public string TaxStatus { get; set; }
    		[XmlElement(ElementName="CabinetList")]
    		public List<InventoryDM> CabinetList { get; set; }
    	}
    }
