    internal sealed class MySutBuilder
    {
        private ISignInService _webServiceSignInService;
        public MySutBuilder()
        {
            _webServiceSignInService = new Mock<ISignInService>().Object;
        }
        public MySutBuilder WithSecurityAccess()
        {
            var authenticationMock = new Mock<ISignInService>();
            authenticationMock.Setup(m => m.SignIn(It.IsAny<GetDocumentContentRequest>()))
                        .Returns(SignInResult.Success(new ServiceUserContextMock()));
               _webServiceSignInService = authenticationMock.Object;
            return this;
        }
        public MyService Build()
        {
            MyService cut = new MyService(_webServiceSignInService);
	
            return cut;
        }
    }
