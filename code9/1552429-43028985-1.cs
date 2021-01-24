	public class Order
	{
		public class Order()
		{
			Requests = new List<OrderDataRequest>();
		}
		public List<OrderDataRequest> Requests { get; set; }
		//OR
		public OrderDataRequest[] Requests { get; set; }
	}
	public class OrderDataRequest
	{
		public OrderDataRequest()
		{
			GoodsInfos = new List<GoodsInfo>();
		}
		public string user_order_sn { get; set; }
		.
		.
		.
		public List<GoodsInfo> GoodsInfos {get; set;}
		//OR
		public GoodsInfo[] GoodsInfo { get; set; }
	}
	public class GoodsInfo
	{
		public string goods_sn { get; set; }
		public string good_number { get; set; }
	}
