    [TestClass]
    public class UnitTestClass {
    	[TestMethod]
    	public void MyFirstUnitTest()
    	{
    		// arrange
    		string f = "hit";
    		string s = "cat";
    
    		// act
    		List<string> lst = new List<string>(){f, "hat", s};
    		var test = string.Join(",", lst);
    		
    		// assert
    		Assert.AreEqual(test, "hit,hat,cat"); // you can append a 3rd boolean parameter if you care about case sensitivity
    	}
    }
