    context.MapRoute(
            "Test_default",
            "Test/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional },
            new string[] { "Project.Web.Controllers", "Project.Web.Areas.Test.Controllers" }  //added this line
        );
