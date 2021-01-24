    void Button_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is TabItem item) {
            var tabControl = (TabControl)item.Parent;
            tabControl.Items.Remove(item);
        }
    }
