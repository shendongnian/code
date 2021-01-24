    private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.AddedItems[0] as ComboBoxItem;
        var itemStackPanel = selectedItem.Contents as StackPanel;
        
        // Get the TextBlock object from 'itemStackPanel' object
        // TextBlock is with index 1 because it is defined second
        //  after Image inside the StackPanel in your XAML
        var textBlock = itemStackPanel.Children[1] as TextBlock;
        // This variable will hold 'Engineer' or 'Manager'
        var selectedText = textBlock.Text;
    }
