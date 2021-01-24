    [TestMethod]
    public async Task TestMethod1()
    {
    	using (ShimsContext.Create())
    	{
    		MyClass obj = new MyClass();
    		ShimHttpClient shimHttpClient = new ShimHttpClient();
    		ShimHttpClient.Constructor = (t) =>
    		{
    			shimHttpClient = new ShimHttpClient();
    			await shimHttpClient.GetAsyncString = (a) =>
    			{
    				return new System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>(function1);
    			};
    		};
    		var returnVal = await obj.GetYourClass();
    		Assert.IsNotNull(returnVal);
            //make more assertations on the returnVal 
    	}
    }
