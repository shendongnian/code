    public decimal Quantity { get; set; }
	public string QuantityDisplay
	{
		get
		{
			return String.Format("{0:0.000}", Quantity);
		}
	}
	[Column("sell_price")]
	[XmlElement(ElementName = "sell_price", Namespace = "http://tempuri.org/DataSet1.xsd")]
	//[DisplayFormat(DataFormatString = "{0:0.00}")]
	public decimal SellPrice { get; set; }
	public string SellPriceDisplay
	{
		get
		{
			return String.Format("{0:0.00}", SellPrice);
		}
	}
