    if (string.IsNullOrEmpty(cusname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirm))
    {
        txtCustName.Visible = true;
        txtEmail.Visible = true;
        txtPassword.Visible = true;
        txtConfirmPassword.Visible = true;
        //etc....
        ShowMessage("Fill all cradentials of customer.");
        showSignUpDialog = true;
    }
