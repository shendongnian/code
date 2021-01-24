    private void btnRemove_Click(object sender, RoutedEventArgs e)
    {
        List<Users> usersToRemove = new List<Users>();
        foreach (Users item in theListview.SelectedItems)
        {
            usersToRemove.Add(item);
        }
        foreach (Users userToRemove in usersToRemove)
        {
            theUsers.Remove(userToRemove);
        }
    }
