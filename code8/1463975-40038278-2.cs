	private void btn_login_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txb_accName.Text) || string.IsNullOrEmpty(txb_password.Text))
		{
			MessageBox.Show("Some fields are empty. Please fill up all fields before clicking LOGIN button.", "Login Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		else
		{
			var manager = new UserManager();
			var user = manager.FindLogin(txb_accName.Text, txb_password.Text);
			if (user != null)
			{
				Inventory Inv = new Inventory();
				Inv.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("You have entered your password or account name incorrectly. Please check your password and account name and try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
