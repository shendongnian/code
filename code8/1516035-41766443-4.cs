    protected void Application_Error()
            {
                
                Exception currentEx = Server.GetLastError();
                ErrorModel errorDetail = null; 
                try
                { 
                    errorDetail = ConstructError(Context, currentEx);                 
                    Context.Items["ErrorObject"] = errorDetail;                 
                    Server.ClearError();
                    Context.Response.Clear();  
                    ReportError();
    
                }
                finally
                {
                    Cleanup(Context, errorDetail);
                }
            }
    
            private static void Cleanup(System.Web.HttpContext context, ErrorModel errorInfo)
            {
                 
                if (errorInfo != null && !errorInfo.IsAjax && errorInfo.ErrorCode == 500)
                {
                    if (context.Session != null)
                    {
                        context.Session.Abandon();
                    }
                }
            }
    
            private static ErrorModel ConstructError(System.Web.HttpContext context, Exception currentEx)
            {
                var model = new ErrorModel();            
    
                model.IsHttpException = currentEx is HttpException;
                model.ErrorCode = model.IsHttpException ? ((HttpException)currentEx).GetHttpCode() : 500;
               
                model.ViewFile = "~/Views/Error.cshtml";
                model.ErrorUrl = context.Request.Url.PathAndQuery;
    
                return model;
            }
    
            private void ReportError()
            {
                Context.Response.ContentType = "text/html";
                var httpWrapper = new HttpContextWrapper(Context);
    
                var routeData = new RouteData();
                routeData.Values.Add("controller", "error");
                routeData.Values.Add("action", "index");
    
                var requestCtx = new RequestContext(httpWrapper, routeData);            
                 
                    var controller = ControllerBuilder.Current.GetControllerFactory().CreateController(requestCtx, "Error");
                    controller.Execute(requestCtx);
                 
    
            }
    		
		
		
		
