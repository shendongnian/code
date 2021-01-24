    private void btnRemove_Click(object sender, RoutedEventArgs e)
    {
        var playerToRemove = items.FirstOrDefault(x => x.Username == "John Doe");
        if (playerToRemove != null)
            items.Remove(playerToRemove);
    }
