	[Fact]
	public void test1()
	{
		try{
			SetupTest();
			//testing something that fails
		}finally{
			TeardownTest();
		}
	}       
