    var Route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
                HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://localhost", ""),
                new HttpResponse(new StringWriter())
                );
                var RouteData = new HttpRouteData(Route, new HttpRouteValueDictionary { { "controller", "unittest" } });
                var Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost");
                controller.ControllerContext = new System.Web.Http.Controllers.HttpControllerContext(config, RouteData, Request);
                controller.Request = Request;
                controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
