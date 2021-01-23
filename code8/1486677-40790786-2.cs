    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public static string TestException()
    {
        try
        {
            System.Web.HttpContext.Current.Response.Redirect("Test.aspx");
            return "No Exception";
        }
        catch(ThreadAbortException ex)
        {
            Thread.ResetAbort();
            return "Exception";
        }
    }
