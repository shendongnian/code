    [System.Web.Services.WebMethod]
    public static string GetCurrentTime(string name){
    return "Hello " + name + Environment.NewLine + "The Current Time is: "
        + DateTime.Now.ToString();
    }
