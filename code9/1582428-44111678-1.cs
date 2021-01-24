    [TestClass]
    public class TestMyMethod 
    {
        [TestMethod]
        public void MyMethod_WithBankApiReturns1_ShouldHaveThingsThatHappens()
        {
            // Arrange
            var apiMock = new Mock<IBankApi>();
            apiMock.Setup(api => api.pay())
                .Returns(1);
            var myObject = new ClassThatUsesYourBankApi(apiMock.Object);
            // Act
            int result = myObject.MethodThatUseTheApi();
            // Assert
            // Here you test that the things that should have happened when the api returns 1 actually have happened.
        }
    } 
