	// the username and password to authenticate
	const string domain = "OU=Organization,DC=mydomain,DC=com";
	string password = "mypass";
	string userName = "myuser";
	// define your connection
	LdapConnection ldapConnection = new LdapConnection("ldap.mydomain.com:389");
	try
	{
	   // authenticate the username and password
	   using (ldapConnection)
	   {
		   // pass in the network creds, and the domain.
		   var networkCredential = new NetworkCredential(username, password, domain);
		   // if we're using unsecured port 389, set to false. If using port 636, set this to true.
		   ldapConnection.SessionOptions.SecureSocketLayer = false;
		   // since this is an internal application, just accept the certificate either way
		   ldapConnection.SessionOptions.VerifyServerCertificate += delegate { return true; };
		   // to force NTLM\Kerberos use AuthType.Negotiate, for non-TLS and unsecured, just use AuthType.Basic
		   ldapConnection.AuthType = AuthType.Basic;
		   // authenticate the user
		   ldapConnection.Bind(networkCredential);
	   }
	   catch (LdapException ldapException)
	   {
		   //Authentication failed, exception will dictate why
	   }
	}
