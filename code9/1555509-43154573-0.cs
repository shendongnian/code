    protected void Button1_Click1(object sender, EventArgs e)
            {
    
                string dominName = "ldap://domain.com";
                string userName = "guest";
                string password = "testlogin";
    
                if (true == AuthenticateUser(dominName, userName, password))
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    Response.Write("Invalid user name or Password!");
                }
    
            }
    private bool AuthenticateUser( string domain, string userName, string password)
    {
        bool authentic = false;
        try
        {
            DirectoryEntry entry = new DirectoryEntry(domain, userName, password);
            entry.Path = "LDAP://OU=allsuers,OU=users,DC=domain,DC=com";
            DirectorySearcher searcher = new DirectorySearcher(entry)
            {
                PageSize = int.MaxValue,
                Filter = "(sAMAccountName=" + userName + ")"
            };
            var result = searcher.FindOne();
            
            if (result == null) {
                return true; 
            }
        }
        catch (DirectoryServicesCOMException) { }
        return authentic;
    }
