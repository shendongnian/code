    public InnerItem Display
    {
        get {
    		if (_details == null)
    		{
    			_details = new InnerItem();
    			_details.Total = 100;
    			_details.Subtotal = 50;
    		}
            return _details;
        }
    }
