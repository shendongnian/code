    private void DoStuff(object sender, EventArgs e)
    {
    	using (Process addgroup = new Process())
    	{
    		string hostname = Environment.MachineName;
    		AddMemberToGroup("LDAP://aa.bbbbb.com/CN=Group,OU=Application,OU=Group,OU=US,DC=aa,DC=bbbbb,DC=com", hostname);
    	}
    }
    
    private void AddMemberToGroup(string ldapString, string host)
    {
    	try
    	{
    		DirectoryEntry de = new DirectoryEntry(ldapString);
    		string distHost = GetDistinguishedName(host);
    		if (!String.IsNullOrEmpty(distHost))
    		{
    			de.Properties["member"].Add(distHost);
    			de.CommitChanges();
    		}
    		else
    		{
    			MessageBox.Show("Distinguished Host Name returned NULL");
    		}
    	}
    	catch(Exception ex)
    	{
    		MessageBox.Show("Group join failed" + Environment.NewLine + Environment.NewLine + ex.ToString());
    	}
    }
    
    private string GetDistinguishedName(string compName)
    {
    	try
    	{
    		PrincipalContext pContext = new PrincipalContext(ContextType.Domain);
    		ComputerPrincipal compPrincipal = ComputerPrincipal.FindByIdentity(pContext, compName);
    		return compPrincipal.DistinguishedName;
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show("Failed to get the Distinguished Hostname from Active Directory" + Environment.NewLine + Environment.NewLine + ex.ToString());
    		return null;
    	}
    }
