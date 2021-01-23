    public bool ValidateTextBox(TextBox textBoxToValidate)
    {
        string error = null;
        string pattern = @"\,\";
        if(Regex.IsMatch(textBoxToValidate.Text, pattern))
        {
            error = "Please use [.] instead of [,]";
    		errorProvider1.SetError(textBoxToValidate, error);
    		return false;
    	}
    	
    	return true;
    }
