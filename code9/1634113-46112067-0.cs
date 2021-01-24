    const string pwRegex = @"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$";
    txtPassword_TextChanged(object sender, TextChangedEventArgs e)
    {
		bool IsValid = false;
		IsValid = (Regex.IsMatch(e.NewTextValue, pwRegex, RegexOptions.IgnoreCase));
		((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
		
		if(!IsValid)
			lblPasswordValidation.Text = "Password is not valid"; // Put the label you want to set here
    }
