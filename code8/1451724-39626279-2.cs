    [TestClass]
    public class UnitTestClass {
    	[TestMethod]
    	public void MyFirstUnitTest()
    	{
    		// arrange
    		string f = "hit";
    		string s = "cat";
    
    		// act - this is not a great example of why to unit test but you had nothing in the OP that would compile so we are testing the output of string.Join
    		List<string> lst = new List<string>(){f, "hat", s};
    		var test = string.Join(",", lst);
    		
    		// assert
    		Assert.AreEqual(test, "hit,hat,cat"); // you can append a 3rd boolean parameter if you care about case sensitivity
    	}
    }
