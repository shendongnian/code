    // you can now mock authentication results, and set them up to 
    // emulate whatever conditions you like
    var mockResult = new Mock<IAuthenticationResultWrapper>();
    // you'll need to use the IAuthenticationContextWrapper, so all the
    // method signatures know about our new IAuthenticationResultWrapper
    var mockAuth = new Mock<IAuthenticationContextWrapper>();
    // here's how we mock the IAuthenticationContextWrapper to return our
    // mocked IAuthenticationResultWrapper
    mockAuth.Setup(x => x.Authenticate(null, param2, param3, param4))
            .Returns(Task.FromResult(mockResult.Object));
