    <asp:TextBox runat="server" ID="UsernameTextBox" />
    <asp:TextBox runat="server" ID="PasswordTextBox" />
    <asp:Button runat="server" ID="SubmitButton" Text="Submit"
       OnClick="SubmitButton_Click" />
    // Code Behind
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string username = UsernameTextBox.Text,
            password = PasswordTextBox.Text;
        bool rememberMe = RememberMeCheckBox.Checked;
        // Retrieve username and hashed password from database, and validate them
        if (username.Equals("johndoe", StringComparison.InvariantCultureIgnoreCase) &&
            password.Equals("123456", StringComparison.InvariantCultureIgnoreCase))
        {
            FormsAuthentication.RedirectFromLoginPage(username, rememberMe);
        }
        MessageLabel.Text = "Invalid username or password";
    }
