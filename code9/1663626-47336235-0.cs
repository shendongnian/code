	public static bool IsEmailValid(string emailAddress)
	{
		const string EmailRegularExpression = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";
		var EmailValidRegex = new Regex(CommonValues.EmailRegularExpression, RegexOptions.Compiled | RegexOptions.IgnoreCase)
		return !string.IsNullOrWhiteSpace(emailAddress) && EmailValidRegex.IsMatch(emailAddress);
	}
