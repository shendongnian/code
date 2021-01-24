    public interface ITest
	{
	    int Value { get; set; }
    }
	public struct TestStruct : ITest
	{
	    public int Value { get; set; }
    }
	
    private static void TestMethodGeneric<T>(T value) where T : ITest
	{
    }
	private static void TestMethodNonGeneric(ITest value)
	{
	}
