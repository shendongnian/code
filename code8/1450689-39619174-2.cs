    public override IEnumerable<object> GetIEnumerableItems()
    {
		return getIEnumerableItems(base.GetIEnumerableItems());
    }
	
	IEnumerable<object> getIEnumerableItems(IEnumerable<object> baseItems) 
    {
	    foreach ( var item in baseItems )
        	yield return item;
	}
