    [TestMethod]
    public async Task Test_NullParam()
    {
        Mock<IAuth> mockAuth = new Mock<IAuth>();
        Task<AuthenticationResult> mockResult = null;
        mockAuth
            .Setup(x => x.Authenticate(null, param2, param3, param4))
            .Returns(mockResult);
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
        {
            await MyMethodAsync();
        });
    }
