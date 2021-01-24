    // Private Method with return type "Boolean" to determine if the method succeed or not.
    private static bool EnableADUserUsingUserPrincipal(string username)
    {
    	try
    	{
    		PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
    		UserPrincipal userPrincipal = UserPrincipal.FindByIdentity
    		(principalContext, username);
    		userPrincipal.Enabled = true;
    		userPrincipal.Save();
    
    		return true;
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    	
    	return false;
    }
    
    
    private void button2_Click(object sender, EventArgs e)
    {
    	String _ADUserName = textBox1.Text; // <-- The textbox you enter your username?
    	
    	// Check if the account is enabled
    	if (EnableADUserUsingUserPrincipal(_ADUserName))
    	{
    		MessageBox.Show("AD Account Enabled for {0}", username);
    		this.StatusTextBox.Text = "Account Enabled";
    	}
    }
