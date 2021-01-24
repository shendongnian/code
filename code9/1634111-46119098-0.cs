    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        User user = dataGrid.SelectedItem as User;
        if (user != null)
        {
            IList<User> users = dataGrid.ItemsSource as IList<User>;
            if (users != null)
                users.Remove(user);
        }
    }
