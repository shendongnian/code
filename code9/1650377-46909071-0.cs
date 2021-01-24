	public void ButtonClick(object sender, EventArgs args)
	{
		// bool valid = fnValLDAPCreds(Environment.UserName, "Password123", Environment.UserDomainName);
		bool valid = fnValLDAPCreds(txtUserName.Text, txtUserPW.Text, Environment.UserDomainName);
	}
	public static bool fnValLDAPCreds(string username, string password, string domain)
	{
		try
		{
			LdapConnection ADConn = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
			NetworkCredential NetCred = new NetworkCredential(username, password,  domain);
			ADConn.Credential = NetCred;
			ADConn.AuthType = AuthType.Negotiate;
			// the user's authenticated here; creds used to login on the domain controller.
			ADConn.Bind(NetCred);
			MessageBox.Show("You were successfully authenticated against AD using LDAP!");
			return true;
		}
		catch (LdapException)
		{
			MessageBox.Show("Your login was unsuccesful. Try a different set of credentials.");
			return false;
		}
	}
