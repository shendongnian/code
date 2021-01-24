                var controllerContextMock = new Mock<ControllerContext>();
    
                var query = new Mock<IQueryCollection>();
                var request = new Mock<HttpRequest>();
                var httpContext = new Mock<HttpContext>();
    
                var response = new Mock<HttpResponse>();
    
                query.SetupGet(q => q["api-version"]).Returns(new StringValues("42.0"));
                request.SetupGet(r => r.Query).Returns(query.Object);                
                httpContext.SetupGet(c => c.Request).Returns(request.Object);
                httpContext.SetupGet(c => c.Response).Returns(response.Object);
                httpContext.SetupProperty(c => c.Items, new Dictionary<object, object>());
                httpContext.SetupProperty(c => c.RequestServices, Mock.Of<IServiceProvider>());
    
                controllerContextMock.Object.HttpContext = httpContext.Object;
