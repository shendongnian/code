	[TestClass]
	public class TestBase
	{
		[AssemblyInitialize]
		public static void BeforeClass(TestContext tc)
		{
		   Console.WriteLine("Before all tests");
		}
		
		[TestInitialize]
		public void BeforeTest()
		{
			   Console.WriteLine("Before each test");
		}
	}
