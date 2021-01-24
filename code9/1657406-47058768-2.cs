    //Input: {"val":42}
    	[HttpPost]
		public dynamic PostDynamic(dynamic value)
		{
			return value.val;
		}
