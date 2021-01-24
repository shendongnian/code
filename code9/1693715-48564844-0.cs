    [SetUpFixture]
    public class MySetUpClass
    {
	  [OneTimeSetUp]
	  public void RunBeforeAnyTests()
	  {
	    // ...
	  }
	  [OneTimeTearDown]
	  public void RunAfterAnyTests()
	  {
	    // ...
	  }
    }
