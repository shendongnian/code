    [Route("bookshop/{pageName}")]
    public ActionResult MyAction(string pageName)
    {
       // Create and use a method to ExtractProductNameFromPageName
       string productName = ExtractProductNameFromPageName(pageName);
       return Response.Redirect("~/" + productName);
    }
