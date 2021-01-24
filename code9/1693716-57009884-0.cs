	public static class StaticFixture
	{
		static StaticFixture()
		{
			AppDomain.CurrentDomain.ProcessExit += (o, e) => Dispose();
			// Initialization code here
		}
		private static void Dispose()
		{
			// Teardown code here
		}
	}
