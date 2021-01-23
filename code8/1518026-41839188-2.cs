    [XmlRoot(ElementName = "row")]
    public class Row
    {
    	[XmlElement(ElementName = "sell_cash")]
    	public string SellCash { get; set; }
    	[XmlElement(ElementName = "sell_tc")]
    	public string SellTc { get; set; }
    }
    
    [XmlRoot(ElementName = "web_dis_rates")]
    public class WebRates
    {
    	[XmlElement(ElementName = "row")]
    	public List<Row> Rows { get; set; }
    }
