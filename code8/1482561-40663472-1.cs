    protected void ServerValidation(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(TextBox12.Text) || !string.IsNullOrEmpty(TextBox13.Text))
                args.IsValid = true;
            else
            { 
                args.IsValid = false;
            }
        }
