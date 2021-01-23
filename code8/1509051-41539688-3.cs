	[TestMethod]
	public async Task NeverCompletes()
	{
		await MessageLoopWorker.Run(async (args) =>
		{
			using (new Form()) ;
			return Type.Missing;
		});
	}
