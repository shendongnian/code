    private async Task btnSave_Click(object sender, RoutedEventArgs e)
    {
         if (users != null)
         {
              List<Users> userList  = await users;
              // Your validations etc.
         }
    }
