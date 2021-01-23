	[TestClass]
	public class MyTestClass
	{
		static MessageLoopApartment s_apartment;
		[ClassInitialize]
		public static void TestClassSetup()
		{
			s_apartment = new MessageLoopApartment();
		}
		[ClassCleanup]
		public void TestClassCleanup()
		{
			s_apartment.Dispose();
		}
		// ...
	}
