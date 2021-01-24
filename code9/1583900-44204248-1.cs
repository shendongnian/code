    try
	{
		using (var context = new PrincipalContext(ContextType.Domain, "website.net"))
		using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, usernameTextBox.Text))      
		user.ChangePassword(oldPasswordTextBox.Text, newPasswordTextBox2.Text);
		MessageBox.Show("Password Changed");                        
	}
	catch (Exception e2)
	{
		MessageBox.Show(e2.ToString());
	}
