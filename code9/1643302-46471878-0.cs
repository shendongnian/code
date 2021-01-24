    private void BarcodeTextBox_OnLostFocus(object sender, RoutedEventArgs e)
    {
        var tb = sender as TextBox;
        Panel grid = tb.Parent as Panel;
        if (grid != null)
        {
            CheckBox checkBox = grid.Children.OfType<CheckBox>().FirstOrDefault(x => x.Name == "IsGoodCheckBox");
            if (checkBox != null)
            {
                //set the IsChecked property based on your logic here...
                checkBox.IsChecked = tb.Text == tb.Tag.ToString();
            }
        }
    }
