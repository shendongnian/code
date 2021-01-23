    private void btnCT_Click(object sender, RoutedEventArgs e)
    {
         try
         {
     
              DataBase db = new DataBase();
              db.IsPasswordCorrect(this.txtBoxUserPassword.Text);
              // If you reach this point the password is correct
              // But it is ugly and unclear to any reader....
         }
         catch(InvalidPasswordException ex)
         {
             MessageBox.Show(ex.Message);
         }
