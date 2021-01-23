	private bool suppressPasswordChanged;
	private void PasswordTextOnPasswordChanged(object sender, RoutedEventArgs e)
	{
		if (!suppressPasswordChanged)
		{
			((LoginFormViewModel)DataContext).Password = PasswordText.SecurePassword;
		}
	}
	public void SetPassword(string password)
	{
		try
		{
			suppressPasswordChanged = true;
			PasswordText.Password = password;
		}
		finally
		{
			suppressPasswordChanged = false;
		}
	}
