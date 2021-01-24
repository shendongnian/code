    var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.NameIdentifier, "testId"),
                     new Claim(ClaimTypes.Name, "testName")
                }));
            this.controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
