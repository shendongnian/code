    static public string GetUsername(string computer)
    {
        string username = string.Empty;
        ConnectionOptions options = new ConnectionOptions();
        options.Username = "YOUR USERNAME";
        options.Password = "YOUR PASSWORD";
        options.Authority = "ntlmdomain:YOURDOMAIN";
        ManagementScope scope = new ManagementScope("\\\\computer\\root\\cimv2",options);
        //scope.Connect(); If I activate this line, the error occurs on this line
        string queryString = "select LogonId from win32_logonsession where logontype = 2";
        ManagementObjectSearcher query = new ManagementObjectSearcher(scope, new SelectQuery(queryString));
        foreach (ManagementObject mo in query.Get()) //if scope.connect(); is not activated, it's blocking on this line
        {
            username = mo["LogonId"].ToString();
        }
        return username;
    }
