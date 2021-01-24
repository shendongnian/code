    public override void OnActionExecuting(HttpActionContext actionContext)
        {
            
            DateTime licenseExp = DateTime.Parse(System.Web.HttpContext.Current.Application["licenseExp"].ToString());            
            if (DateTime.Compare(licenseExp, DateTime.UtcNow) < 0)
            {
                throw new Exception("Your license as expired.");
            }            
        }
