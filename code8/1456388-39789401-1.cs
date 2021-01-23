    public void UrlTest() {
        Mock.Arrange(() => HttpContext.Current.Request.RequestContext)
            .Returns(Mock.Create<RequestContext>());
    
        var mockedUrl = Mock.Create<UrlHelper>(Constructor.Mock);
        var mockedAccessor = Mock.Create<IUrlHelperAccessor>();
        Mock.Arrange(() => mockedAccessor.UrlHelper).Returns(mockedUrl);
    
        //Here url will have actual instance instead of mocked instance
        var model = new UrlModel(mockedAccessor);
    
        //Assert is omitted for brevity .. 
    
    }
