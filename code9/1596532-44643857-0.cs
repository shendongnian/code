    string Url = Request.RawUrl; 
    string TestUrl = Url.Split('&')[0];
    string SessionData = Session["Authenticate"].ToString();
    if (TestUrl.EndsWith("User_EditPassword.aspx?accesstype=email"))
    {
        HttpContext.Current.SkipAuthorization = true;
    }
