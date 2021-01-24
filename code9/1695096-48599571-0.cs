    [TestFixture]
    public class SomeClassTests
    {
    	[OneTimeTearDown]
    	public void Cleanup()
    	{
    		Assert.Fail("Failed to upload file to the PACT broker");
    	}
    
    	[Test]
    	public void TestMethod()
    	{
    		Assert.Pass();
    	}
    }
