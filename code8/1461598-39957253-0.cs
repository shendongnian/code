    public string  UserId
    {
        get 
        {
            return (string)System.Web.HttpContext.Current.Session["UserId"];
        }
        set
       {
           System.Web.HttpContext.Current.Session["UserId"] = value;
       }
    }
