	// place in new code file
	public class UserManager{
		public BELLogin FindLogin(string userName, string password){
			if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
				return null;
			
			using(var connection = new SqlConnection("connectionStringPointerFromAppConfigHere"))
			using(SqlCommand cmd = new SqlCommand("SELECT username,password FROM tbl_login WHERE username = @Username AND password = @Password", connection))
			{
				connection.Open();
				cmd.Parameters.AddWithValue("@Username", bellog.Acctname).SqlDbType = SqlDbType.VarChar;
				
				// BAD practice! Use a secure hash instead and store that not the password!
				cmd.Parameters.AddWithValue("@Password", bellog.Password).SqlDbType = SqlDbType.VarChar;
				using(SqlDataReader dr = cmd.ExecuteReader())
				{
					if(dr.Read())
						return new BELLogin() {Acctname = dr.GetString(0), Password = dr.GetString(1)}; // passed in is same as in datareader
				}
			}
			return null;
		}
	}
	// in your form class
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
