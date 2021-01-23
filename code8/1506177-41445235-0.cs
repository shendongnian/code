    public async Task<YourClass> GetAllStatsAsync()
    {
        // Some code...
        var fCount = 1;
        var cCount = 1;
        var aCount = 1;
        var yourClass = new YourClass(fCount, cCount, aCount);
        return (yourClass);
    }
	public async Task<HttpResponseMessage> GetInfoAsync()
	{
		// Some code...
		var stats = await _myClass.GetAllStatsAsync();
		var vm = new ViewModel
				 {
					 FCount = stats.TResult.fCount,
					 CCount = stats.TResult.cCount,
					 ACount = stats.TResult.aCount
				 };
		 return Request.CreateResponse(HttpStatusCode.OK, vm);
	}
    class YourClass
    {
        public System.Int32 fCount {get; set;}
        public System.Int32 cCount {get; set;}
        public System.Int32 aCount {get; set;}
    }
