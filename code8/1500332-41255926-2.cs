	private bool _textChangedEventBusy;
	private void PasswordTextOnPasswordChanged(object sender, RoutedEventArgs e)
	{
		try
		{
			_textChangedEventBusy = true;
			((LoginFormViewModel)DataContext).Password = PasswordText.SecurePassword;
		}
		finally
		{
			_textChangedEventBusy = false;
		}
	}
	public void SetPassword(string password)
	{
		if (!_textChangedEventBusy)
		{
			PasswordText.Password = password;
		}
	}
