       private void btnLogin_Click(object sender, EventArgs e) {
         if (!UserExists(txtBoxUsername.Text, txtBoxPassword.Text))  
           lblerrorInput.Show();
         else {
           Hide();
           Main ss = new Main();
           ss.Show();
         }
       }
