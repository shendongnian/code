    protected void Button1_Click(object sender, EventArgs e)
    {
        // Username and password text
        var username1 = uniloginTextBox.Text;
        var password1 = passwordTextBox.Text;
        // isValid defaults to false
        bool isValid = false;
        // Check credentials against AD
        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cv.local"))
        {
            // Set value for isValid
            isValid = pc.ValidateCredentials(username1, password1, ContextOptions.Negotiate);
        }
        // Achieves the same as your if statement
        Label.Text = isValid ? "Approved" : "Denied";
    }
