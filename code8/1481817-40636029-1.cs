    public void Foo(int? someChainId, int? someSheetId, bool required = false)
    {
    	ControllerHelper hlp = new ControllerHelper();
        using (UranusContext db = new UranusContext())
    	{
            hlp.DeleteChain(someChainId);
    		
    		if(_required)
    			hlp.DeleteSheet(int? someSheetId);
    		
    		db.SaveChanges();
        }
    }
