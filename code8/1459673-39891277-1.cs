    public Holder<PointF> MyFunc()
    {
    	try
    	{
    		//
    		return Holder<PointF>.Success(new PointF());
    	}
    	catch
    	{
    		return Holder<PointF>.Fail(101);
    	}
    }
