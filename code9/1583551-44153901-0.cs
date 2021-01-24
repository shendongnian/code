	[TestClass]
	public class TestBase
	{
		[AssemblyInitialize]
		public static void BeforeClass(TestContext tc)
		{
		   Console.Writeline("Before all tests");
		}
		
		[TestInitialize]
		public void BeforeTest()
		{
			   Console.Writeline("Before each test");
		}
	}
