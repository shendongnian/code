	private void Calculations()
	{
		for (int i = 0; i< UserAccounts.Count ; i++)
		{
			if (UsernameLogin.Text.Equals(UserAccounts[i].Username) && PasswordLogin.Text.Equals(UserAccounts[i].Password))
			{
				Booking bookings = new Booking();
				bookings.Show();
				this.Hide();
				break;
			} else {
				MessageBox.Show("Please check your username or password");
				UsernameLogin.Focus();
			}
		
		}
	}
