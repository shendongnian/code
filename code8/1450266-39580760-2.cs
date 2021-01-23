    [Test]
    public void TestFooCalledSomethingHeavy() 
    {
        // Arrange
        IModel fakeModel = Substitute.For<IModel>();
        SomeClass someClass = new SomeClass(fakeModel); 
        // Act 
        someClass.Foo();  
        // Assert      
        fakeModel.Received().DoSomethingHeavy();
    }
   
