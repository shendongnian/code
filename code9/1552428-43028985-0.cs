	public class CreateOrderDataRequest
	{
		.
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
