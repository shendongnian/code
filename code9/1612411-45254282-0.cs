    [Test]
    public void New_GUID_should_be_added_when_OnActionExecuting_is_executing()
    {
        //arrange section:
        const string REQUEST_GUID_FIELD_NAME = "RequestGUID";
        var httpContext = new HttpContext(
            new HttpRequest("", "http://google.com", ""),
            new HttpResponse(new StringWriter())
        );
        HttpContext.Current = httpContext;
        
        //act:
        target.OnActionExecuting(new HttpActionContext());
        
        //assert section:
        Assert.IsTrue(HttpContext.Current.Items.Contains(REQUEST_GUID_FIELD_NAME));
        var g = HttpContext.Current.Items[REQUEST_GUID_FIELD_NAME] as Guid?;
        if (g == null)
        {
            Assert.Fail(REQUEST_GUID_FIELD_NAME + 
                        " is not a GUID, it is :: {0}", 
                        HttpContext.Current.Items[REQUEST_GUID_FIELD_NAME]);
        }
        Assert.AreNotEqual(Guid.Empty, g.Value);
    }
