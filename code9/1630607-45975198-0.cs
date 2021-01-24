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
				OpenDbase("Update USER set Password '" + Hash(this.npw.Text) + "'");
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
		// Get Password hash out of database
		var passwd = OpenDbase("SELECT Password FROM <???> WHERE USER=user");
		
		if(/*No results found, i.e. user not in db*/){
			return false;
		} else {
			return passwd = Hash(password);
		}
	}
	
	private string Hash(string text){
		// Apply SHA256 to the string and return the result
	}
