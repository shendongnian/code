    public static class MyApiControllerExtensions
    {
        public IHttpActionResult GetCustomMessage(this ApiController ctrl)
        {
            // this won't work because the method is protected
            // return ctrl.InternalServerError();
            // so the workaround is return whatever the InternalServerError returns
            if (Request.RequestUri.Host.Contains("company1")) 
            {
                 return new System.Web.Http.Results.ExceptionResult(new Exception("Custom message for company1"), ctrl);
            }
            if (Request.RequestUri.Host.Contains("company2"))
            {
                 return new System.Web.Http.Results.ExceptionResult(new Exception("Custom message for company2"), ctrl);
            }
            if (Request.RequestUri.Host.Contains("company3")) 
            {
                 return new System.Web.Http.Results.ExceptionResult(new Exception("Custom message for company3"), ctrl);
            }
        }
    }
