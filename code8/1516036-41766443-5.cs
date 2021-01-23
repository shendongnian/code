	public ActionResult Index()
    {
        // Retrieve error object from either HttpContext or Session
        ErrorModel err = this.HttpContext.Items["ErrorObject"] as ErrorModel ?? Session["ErrorObject"] as ErrorModel;           
        this.Response.ClearHeaders();             
            Response.ContentType = "text/html";
            Response.Write(RenderToString(err.ViewFile, err));
         
    }
	
	  private string RenderToString(string controlName, object viewData)
    {
        using (var sw = new StringWriter())
        {
            var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, controlName);
            var viewContext = new ViewContext(ControllerContext, viewResult.View, new ViewDataDictionary(viewData), TempData, sw);
            viewResult.View.Render(viewContext, sw);
            return sw.GetStringBuilder().ToString();
        }
    }
		
	
