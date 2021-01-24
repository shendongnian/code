    void HandleTextChanged(object sender, TextChangedEventArgs e)
    {
    
        bool IsValid = false;
        IsValid = (Regex.IsMatch(e.NewTextValue, pwRegex,RegexOptions.IgnoreCase));
        ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        
        // LABEL CODE
        Label errorLabel = ((Entry)sender).FindByName<Label>("errorMessage");
        if (IsValid)
        {
            errorLabel.Text = "Passowrd Invalid or whatever!";
        }
        else
        {
            errorLabel.Text = "";
        }
    }
