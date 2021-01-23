    private string login;
    public string Login
    {
        get { return login; }
        set { login = value; }
    }
    public bool compdetailsrpt(string login, string name, string type, string word)
    {
        Login = HttpContext.Current.Session["loginuser"].ToString();
        return Login != null;
    }
