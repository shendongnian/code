    private void ListButton_Click(object sender, RoutedEventArgs e)
    {
        int index = myList.Items.IndexOf((e.OriginalSource as FrameworkElement).DataContext);
        myList.Items.Insert(index, $"Btn {myList.Items.Count}");
    }
