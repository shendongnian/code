	public override IEnumerable<object> GetIEnumerableItems()
	{
	    foreach ( var item in baseItems() )
		{
	        yield return item;
		}
	}
		
	IEnumerable<object> baseItems() 
    {
		return base.GetIEnumerableItems();
	}
