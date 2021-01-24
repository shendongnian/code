    authServiceMock.AuthenticateAsync(Arg.Any<HttpContext>(), Arg.Any<string>())
        .Returns(Task.FromResult(AuthenticateResult.Success()));
    providerMock.GetService(typeof(IAuthenticationService))
        .Returns(authServiceMock);
    httpContextMock.RequestServices.Returns(providerMock);
    //...
