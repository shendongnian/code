	private const string EmailRegularExpression = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
	private static Regex EmailValidRegex = new Regex(CommonValues.EmailRegularExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase)
	public static bool IsEmailValid(string emailAddress)
	{
		return !string.IsNullOrWhiteSpace(emailAddress) && EmailValidRegex.IsMatch(emailAddress);
	}
