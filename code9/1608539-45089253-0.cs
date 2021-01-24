        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            LogException(exception);
            if (exception is HttpAntiForgeryException)
            {
                Response.Clear();
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                // Call target Controller and pass the routeData.
                IController controller = EngineContext.Current.Locator.GetInstance<CommonController>();
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Common");
                routeData.Values.Add("action", "AntiForgery");
                var requestContext = new RequestContext(new HttpContextWrapper(Context), routeData);
                controller.Execute(requestContext);
            }
            else
            {
                // Process 404 HTTP errors
                var httpException = exception as HttpException;
                if (httpException != null && httpException.GetHttpCode() == 404)
                {
                    Response.Clear();
                    Server.ClearError();
                    Response.TrySkipIisCustomErrors = true;
                    // Call target Controller and pass the routeData.
                    IController controller = EngineContext.Current.Locator.GetInstance<CommonController>();
                    var routeData = new RouteData();
                    routeData.Values.Add("controller", "Common");
                    routeData.Values.Add("action", "PageNotFound");
                    var requestContext = new RequestContext(new HttpContextWrapper(Context), routeData);
                    controller.Execute(requestContext);
                }
            }
        }
        private void LogException(Exception ex)
        {
            if (ex == null)
                return;
            // Ignore 404 HTTP errors
            var httpException = ex as HttpException;
            if (httpException != null &&
                httpException.GetHttpCode() == 404)
                return;
            try
            {
                // Log error message
            }
            catch (Exception)
            {
                // Don't throw new exception if occurs
            }
        }
