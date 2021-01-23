    [XmlRoot(ElementName="TOPUPRESPONSE")]
    	public class TOPUPRESPONSE {
    		[XmlElement(ElementName="RESULT")]
    		public string RESULT { get; set; }
    		[XmlElement(ElementName="RESULTTEXT")]
    		public string RESULTTEXT { get; set; }
    		[XmlElement(ElementName="TERMINALID")]
    		public string TERMINALID { get; set; }
    		[XmlElement(ElementName="TXID")]
    		public string TXID { get; set; }
    		[XmlElement(ElementName="PRODUCTID")]
    		public string PRODUCTID { get; set; }
    	}
