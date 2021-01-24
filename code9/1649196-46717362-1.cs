	bool userFound = false;
	using(OleDbConnection connection = new OleDbConnection(/*add your connection string here*/))
	using(OleDbCommand command = new OleDbCommand("select 1 from User_Info where Username = ? AND Password = ?", connection))
	{
		command.Parameters.Add(new OleDbParameter("@username", OleDbType.VarChar)).Value = txt_Username.Text;
		command.Parameters.Add(new OleDbParameter("@password", OleDbType.VarChar)).Value = txt_Password.Text;
		
		connection.Open();
		userFound = command.ExecuteScalar() != null;
	}
	if (userFound)
	{
		MessageBox.Show("Login Successful!", "Success!");
		this.Hide();
		User_Account_Screen UAS = new User_Account_Screen();
		UAS.Number = accountnumber;
		UAS.ShowDialog();
	}
