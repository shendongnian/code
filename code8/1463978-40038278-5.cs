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
