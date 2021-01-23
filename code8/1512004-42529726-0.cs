    [Test]
    public void OnAuthorization_ReturnsErrorWhenThereIsNoToken()
    {
      var resolver = new Mock<IDependencyResolver>();
      resolver.Setup(x => x.GetService(It.IsAny<Type>())).Returns(
        (Type t) =>
          {
            if (t == typeof(TokenService))
            {
              return new TokenService();
            }
    
            if (t == typeof(TokenService))
            {
              return new UserService();
            }
    
            return null;
          });
    
      var original = GlobalConfiguration.Configuration.DependencyResolver;
    
      GlobalConfiguration.Configuration.DependencyResolver = resolver.Object;
      var ctx = new HttpActionContext
                  {
                    ControllerContext =
                      new HttpControllerContext { Request = new HttpRequestMessage() }
                  };
    
      var target = new Attrr();
    
      target.OnAuthorization(ctx); // no token
    
      Assert.AreEqual(HttpStatusCode.Unauthorized, ctx.Response.StatusCode);
      Assert.AreEqual("Token not found", (ctx.Response.Content as StringContent).ReadAsStringAsync().Result);
      // we need this to ensure the test state is restored after test
      GlobalConfiguration.Configuration.DependencyResolver = original;
    }
