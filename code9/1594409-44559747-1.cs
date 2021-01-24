	public class Application
	{
		private Token _token = null;
	
		public void logInMethod()
		{
			LogIn logInObject = new LogIn();
			_token = logInObject.logUserIn("user", "password");
		}
	}
	
	public abstract class Token
	{
		public abstract string UserName { get; }
		public abstract bool Validated { get; }
	}
	
	public class LogIn
	{
		private class TokenImpl : Token
		{
			public TokenImpl(string userName, bool validated)
			{
				_userName = userName;
				_validated = validated;
			}
			private string _userName;
			private bool _validated;
			public override string UserName { get { return _userName; } }
			public override bool Validated { get { return _validated; } }
		}
		
		public Token logUserIn(string userName, string password)
		{
			return new TokenImpl(userName, password == "pAssw0rd");
		}
	}
