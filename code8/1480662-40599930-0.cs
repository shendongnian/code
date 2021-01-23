    void InitLogin(System.Web.HttpSessionStateBase Session, 
                 System.Web.HttpApplicationStateBase Application)
    {
        Session["var1"] = "someval1";
        Application["var2"] = "someval2";
    }
