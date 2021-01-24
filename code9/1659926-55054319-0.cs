        [TestMethod]
            public async System.Threading.Tasks.Task InvokeAsyncNameAsync()
    {
    # setup mocks
    ...
    var httpContext = new DefaultHttpContext();
                var viewContext = new ViewContext();
                viewContext.HttpContext = httpContext;
                var viewComponentContext = new ViewComponentContext();
                viewComponentContext.ViewContext = viewContext;
    
                var footerComponent = CreateComponentInstance();
                footerComponent.ViewComponentContext = viewComponentContext;
    
                ViewViewComponentResult result = await footerComponent.InvokeAsync() as ViewViewComponentResult;
                FooterModel resultModel = (FooterModel)result.ViewData.Model;
    
    ....
    # do your asserts verifications
    
                Assert.AreEqual(expectedTest, resultModel.FooterText);
    }
