    [XmlRoot(ElementName = "CurrencyGuide")]
    public class CurrencyGuide
    {
    	[XmlAttribute(AttributeName = "BaseSwift")]
    	public string BaseSwift { get; set; }
    	[XmlAttribute(AttributeName = "Swift")]
    	public string Swift { get; set; }
    	[XmlAttribute(AttributeName = "Amount")]
    	public string Amount { get; set; }
    	[XmlText]
    	public string Text { get; set; }
    }
    
    [XmlRoot(ElementName = "row")]
    public class Row
    {
    	[XmlElement(ElementName = "swift_code")]
    	public string Swift_code { get; set; }
    	[XmlElement(ElementName = "swift_name")]
    	public string Swift_name { get; set; }
    	[XmlElement(ElementName = "multiply")]
    	public string Multiply { get; set; }
    	[XmlElement(ElementName = "buy_cash")]
    	public string Buy_cash { get; set; }
    	[XmlElement(ElementName = "buy_tc")]
    	public string Buy_tc { get; set; }
    	[XmlElement(ElementName = "sell_cash")]
    	public string Sell_cash { get; set; }
    	[XmlElement(ElementName = "sell_tc")]
    	public string Sell_tc { get; set; }
    	[XmlElement(ElementName = "CurrencyGuide")]
    	public CurrencyGuide CurrencyGuide { get; set; }
    	[XmlElement(ElementName = "base_swift")]
    	public string Base_swift { get; set; }
    }
    
    [XmlRoot(ElementName = "web_dis_rates")]
    public class Web_dis_rates
    {
    	[XmlElement(ElementName = "timestamp")]
    	public Timestamp Timestamp { get; set; }
    	[XmlElement(ElementName = "row")]
    	public List<Row> Rows { get; set; }
    	[XmlElement(ElementName = "copyright")]
    	public string Copyright { get; set; }
    }
