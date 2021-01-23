    private void btnCT_Click(object sender, RoutedEventArgs e)
    {
         try
         {
     
              DataBase db = new DataBase();
              db.IsPasswordCorrect(this.txtBoxUserPassword.Text);
              // If you reach this point the password is correct
         }
         catch(InvalidPasswordException ex)
         {
             MessageBox.Show(ex.Message);
         }
