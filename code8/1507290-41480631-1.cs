    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Form["submitter"] == "foo")
        {
            // the foo button was clicked
        }
        if (context.Request.Form["submitter"] == "bar")
        {
            // the bar button was clicked
        }
    }
