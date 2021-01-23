    [WebMethod]
    public static string Loggingout(string a)
    {
        // if you use FormsAuthentication call this.
        FormsAuthentication.SignOut();
        // You can clear your session....
        HttpContext.Current.Session.Clear();
        // ... or just set your session to a new object.
        HttpContext.Current.Session["__MySession__"] = new MySession();
        return "done";
    }
