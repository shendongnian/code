	public static class MyHelperClass<T> where T : TheCommonParent
	{
		public static ObjectOut Method(T obj)
		{
		   if (obj.ErrorCode == 0)
		   {
			  //do something
		   }
		}
	}
