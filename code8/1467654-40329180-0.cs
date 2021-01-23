            protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var statusCode = exception.GetType() == typeof (HttpException) ? ((HttpException) exception).GetHttpCode() : 500;
            var routeData = new RouteData
            {
                Values =
                {
                    {"controller", "Error"},
                    {"action", "Index"},
                    {"statusCode", statusCode},
                    {"exception", exception}
                }
            };
            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;
            IController errorController = new ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            Response.End();
        }
    }
