    [TestMethod]
    public async Task Test_NullParam()
    {
        // create all of your mocks that are required to run this test
        Mock<IAuth> mockAuth = new Mock<IAuth>();
        Task<AuthenticationResult> mockResult = null;
        mockAuth
            .Setup(x => x.Authenticate(null, param2, param3, param4))
            .Returns(mockResult);
        // you actually need to create the concrete type you want to test
        // you shouldn't make a unit test that just uses mocks!
        // construct the concrete type and pass in any mocks that the 
        // object requires
        var objectToTest = new MyRealObject(mockAuth.Object);
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
        {
            // actually execute the real method here, the assertion
            // is expecting this method to throw an exception, and will
            // only pass if an exception is thrown
            await objectToTest.MyMethodAsync();
        });
    }
