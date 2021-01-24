    private void saveUserPanel_Click(object sender, RoutedEventArgs e)
    {
      var user = (sender as Button).DataContext as User;
      if(user != null)
      {
        user.Name = "NewName";
        var active = user.Aktiv;
        // ...
      }
    }
    
