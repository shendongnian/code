    [Fact]
	public void MyUnitTestWithSQL()
	{
        using (var session = factory.OpenSession(new XUnitSqlCaptureInterceptor(this.output)))
        {
    	    using (var transcation = session.BeginTransaction())
    	    {
    		
    	    }
        }
    }
