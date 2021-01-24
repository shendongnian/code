    [TestClass]
    public class ClassToTestTests
    {
    	[TestMethod]
    	public void SomeMethodWeWantToTest_ShouldAddUpAllNumbersFromDatabaseCorrectly()
    	{
    			Mock<IDataAccessService> dataAccessServiceMock = new Mock<IDataAccessService>();
    			dataAccessService.Setup(x=>x.GetSomeNumbersFromTheDatabase()).Returns(new List<int>{1,2,3,4,5});
    			ClassToTest classToTest = new ClassToTest(dataAccessService.Object());
    			int expected = 15;
    			Assert.AreEqual(expected, classToTest.SomeMethodWeWantToTest());
    	}	
    }
