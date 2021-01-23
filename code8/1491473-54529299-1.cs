    [TestClass] 
    public class MockLocalFunctions 
    { 
        [TestMethod] 
        public void BasicUsage() 
        { 
            //Arrange 
            var foo = Mock.Create<Foo>(Behavior.CallOriginal); 
            Mock.Local.Function.Arrange<int>(foo, "GetResult", "GetLocal").DoNothing(); 
     
            //Act 
            var result = foo. GetResult(); 
     
            //Assert 
            Assert.AreEqual(100, result); 
        } 
    } 
