     if (emptyBoxes.Count != 0) 
     {
        err = string.Join(", ", emptyBoxes) + " cannot be empty";
        lblError.Text = err;
     }
     if (!txtPassword.Text.Equals(txtPwdConf.Text))
     {
          lblError2.Text = "Passwords do not match!";
     }
     if (!string.IsNullOrEmpty(txtPassword.Text))
     {
          String password = txtPassword.Text;
          Match pw = Regex.Match(password, @"((?=.*\d)(?=.*[A - Z])(?=.*\W).{ 8,50})", RegexOptions.IgnorePatternWhitespace);
            if (!pw.Success)
            {
                lblError3.Text = "Passowrd is not valid.";
            }
        }
