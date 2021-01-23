    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Form["foo"] == "foo")
        {
            // the foo button was clicked
        }
        if (context.Request.Form["bar"] == "bar")
        {
            // the bar button was clicked
        }
    }
