    public static bool ValidateUser(string pass)
    {
       bool validation;
       try
       {
           LdapConnection lcon = new LdapConnection
                   (new LdapDirectoryIdentifier((string)null, false, false));
           NetworkCredential nc = new NetworkCredential(Environment.UserName,
                                pass,Environment.UserDomainName);
           lcon.Credential = nc;
           lcon.AuthType = AuthType.Negotiate;
           // user has authenticated at this point,
           // as the credentials were used to login to the dc.
           lcon.Bind(nc);
           validation = true;
       }
       catch (LdapException)
       {
           validation = false;
       }
       return validation;
    }
