    //cs head
    using System.Web.Services;
    [WebMethod(EnableSession=true)]
    public static void addQuot(string name)
    {
        //this is how to access Session object in a static method
        HttpContext.Current.Session["name"] = name;
    }
