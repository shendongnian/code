    internal static AsyncLocal<string> Username = new AsyncLocal<string>();
    internal static AsyncLocal<string> Password = new AsyncLocal<string>();
    
    public WCFWrapper(string username, string password) : this()
    {
    	Username.Value = username;
    	Password.Value = password;
    }
