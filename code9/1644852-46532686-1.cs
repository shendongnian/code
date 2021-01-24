	[DataContract]
	public class Details
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		[DataMember(Name = "sku")]
		public string Sku { get; set; }
		[DataMember(Name = "quantity")]
		public int? Quantity { get; set; }
		[DataMember(Name = "unit_price")]
		public int UnitPrice { get; set; }
		[DataMember(Name = "total_price")]
		public int TotalPrice { get; set; }
	}
    [DataContract]
    public class Item : Details
	{
		[DataMember(Name = "type")]
		[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
		public OrderItemType Type { get; set; }
		[DataMember(Name = "sub_items")]
		public List<Item> SubItems { get; set; }
	}
	[DataContract]
    public class OrderItemModifier : Details
	{
		[DataMember(Name = "type")]
		[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
		public OrderModifierType Type { get; set; }
	}
