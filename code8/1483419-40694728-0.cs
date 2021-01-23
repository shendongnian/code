	public class CustomAuthenticator : UserNamePasswordValidator
	{
		public override void Validate(string userName, string password)
		{
			try
			{
				if (userName.Equals("user") && password.Equals("pass"))
				{
					//Good to go
				}
				else
				{
					// add this line
					throw new SecurityTokenException("Unknown Username or Password");
				}
			}
			catch (Exception ex)
			{
				throw new FaultException("Authentication failed");
			}
		} 
	}
