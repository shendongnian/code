    [TestMethod]
    public async Task ExampleTest() {
        //arrange
        Mock<IUnitOfWork> mockUow = MockUowFactory.Get(nameof(ExampleTest));
        
        //act
        using (var app = YOURAPP(mockUow.Object)){
             app.METHODUNDERTEST();
        }
        //assert
        ...
    }
