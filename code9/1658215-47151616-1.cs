    private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (UserList.SelectedItem is User user)
        {
            UserViewModel = user; 
            NameTextBox.DataContext = UserViewModel;
        }
    }
