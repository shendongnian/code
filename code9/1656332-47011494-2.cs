    // Declare this somewhere permanent
    ObservableCollection<User> users = new ObservableCollection<User>();
    users.Add(new User { Name = "Test1" });
    users.Add(new User { Name = "Test2" });
    users.Add(new User { Name = "Test3" });
    normalUsersListbox.ItemsSource = users;
