    PasswordValid(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
    {
        //Check if an integer was entered if the length is <= 9
        int integer;
        if(passwordTextbox.Text.Length <= 9 && Int32.TryParse(passwordTextbox.Text, out integer))
        {
             args.IsValid = true;
        }
        else if (passwordTextbox.Text.Length > 9)
        {
            args.IsValid = true;
        }
        else 
        {
             args.IsValid = false;
        }
    }
