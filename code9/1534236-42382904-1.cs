    private void btnAddSomething_Click(object sender, RoutedEventArgs e)
    {
        canControlContainer.Children.Clear(); // will remove previous contols from this canvas
        // UC_AddSomething be the user control that you wanted to add here
        canControlContainer.Children.Add(new UC_AddSomething());
    }
