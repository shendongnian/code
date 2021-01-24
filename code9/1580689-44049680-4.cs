       private void btnexit_Click(object sender, EventArgs e) {
         if (TryLogin(txtusername.Text, txtpassword.Text)) {
           frmHome Home = new frmHome();
           Home.Show();
           this.Hide();
         }
         else { 
           MessageBox.Show("Wrong Username or/and Password");
           txtusername.Clear();
           txtpassword.Clear();
    
           if (txtusername.CanFocus) 
             txtusername.Focus();  
         }
       }
