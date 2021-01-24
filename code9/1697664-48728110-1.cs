    using Novell.Directory.Ldap;
    public bool LoginLdap(string username, string password)
        {
            LdapConnection connection = new LdapConnection();
            var loggedIn = false;
            try
            {
                connection.Connect(_config["Ldap:url"], LdapConnection.DEFAULT_PORT);
                connection.Bind(LdapConnection.Ldap_V3, _config["Ldap:domain"] + @"\" + username, password);
                loggedIn = true;
            }
            catch (Exception)
            {
                //throw new Exception("Login failed.");
                loggedIn = false;
            }
            connection.Disconnect();
            return loggedIn;
        }
