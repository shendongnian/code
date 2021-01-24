    Regex regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{7}$");
    string[] splitArray = Regex.Split(Clipboard.GetText(), @"[^a-zA-Z\d]+");
    foreach (string s in splitArray)
    {
        if (regex.IsMatch(s))
		{
			// s is a valid service tag
		}
    }
