    public override IEnumerable<object> GetIEnumerableItems()
    {
		return getIEnumerableItems();
    }
	
	IEnumerable<object> getIEnumerableItems() 
    {
	    foreach ( var item in base.GetIEnumerableItems() )
        	yield return item;
	}
