    private void Done_Checked(object sender, RoutedEventArgs e)
    {
        StackPanel sp = (StackPanel)VisualTreeHelper.GetParent((CheckBox)sender);
        outputArea.Children.Remove(sp);
        completedList.Children.Add(sp);
    }
