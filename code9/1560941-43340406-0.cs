    if (!Regex.IsMatch(txtPassword.Text, @"(!|@|#)") || !txtPassword.Text.Any(char.IsDigit))
    {
    	Console.WriteLine("Password Must Contain at least a special character and digit");
    }
    else
    {
    	// DO YOUR STUFF
    }
