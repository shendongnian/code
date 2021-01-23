	public static string GetMessage(string text)
	{
		string message;
		int number;
		if (int.TryParse(text, out number))
		{
			if (number > 10)
				message = " number must be below 10";
			else
				message = " Good ! You entered ; " + number;
		}
		else
			message = " Not valid Number";
			
		return message; // This is the part you missed.
	}
