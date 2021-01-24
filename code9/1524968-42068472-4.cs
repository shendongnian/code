    private void btnOk_Click(object sender, EventArgs e) {
      MyLogin m = new myLogin(loginTextBox.Text, passwordtextBox.Text);
    
      if (m.IsValid) 
      {
          displayLabel.Text = "The information entered is:";  
          resultLogin.Text = $"Login: {m.Login}";
          resultPassword.Text = $"Password: {m.Password}";
      }
      else 
          displayLabel.Text = "Enter information above";
    }
