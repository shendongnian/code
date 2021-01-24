	private void Button_Click(object sender, RoutedEventArgs e)
	{
		if(CheckPassword(usrnm.Text, password.Text))
		{
			MainWindow main = new MainWindow();
			main.Show();
			this.Hide();
		}
		else
		{
			MessageBox.Show("Username or Password is Incorrect.");
		}
	}
	
	private void btn_save_Click(object sender, RoutedEventArgs e)
	{		
		if (CheckPassword(<usrnm.Text?>, opw.Text))
		{
			if (npw.Text == cpw.Text)
			{
                var salt = //Generate random string for salt
				OpenDbase("Update USER set Salt '" + salt + "'");
                OpenDbase("Update USER set Password '" + Hash(this.npw.Text, salt) + "'");
				DataTable dtable = new DataTable();
				MessageBox.Show("Password has been changed.");
			}
			else
			{
				MessageBox.Show("Npw and Cpw mismatched.");
			}
		}
		else 
		{
			MessageBox.Show("Opw was Incorrect.");
		}
	}
	
	private bool CheckPassword(string user, string password){
		// Get Password hash & salt out of database
		var passwd = OpenDbase("SELECT Password FROM <???> WHERE USER=user");
		var salt = OpenDbase("SELECT Salt FROM <???> WHERE USER=user");
		if(/*No results found, i.e. user not in db*/){
			return false;
		} else {
			return passwd == Hash(password, salt);
		}
	}
	
	private string Hash(string text, string salt){
		// Apply e.g. SHA256 to the string and return the result
	}
