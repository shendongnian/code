    [Xunit.Fact]
    public async System.Threading.Tasks.Task SavePassNotEqualTest()
    {
        var controller = new Controllers.PasswordRecoveryController(_mockRepo.Object);
        var dic = new System.Collections.Generic.Dictionary<string, Microsoft.Extensions.Primitives.StringValues>();
        dic.Add("password", "test");
        dic.Add("password1", "test1");
        var collection = new Microsoft.AspNetCore.Http.FormCollection(dic);
        // Give the controller an HttpContext.
        controller.ControllerContext = new ControllerContext {
            HttpContext = new DefaultHttpContext()
        };
        // Request is not null anymore.
        controller.Request.Form = collection;  
    
        var result = await controller.Save();
        var viewResult = Xunit.Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
        Xunit.Assert.Equal("~/Views/Message.cshtml", viewResult.ViewName);
    }
