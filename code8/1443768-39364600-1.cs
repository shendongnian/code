    private static void ToggleTextBoxVisibility(object sender) {
        if(!(sender is CheckBox)) {
            return;
        }
        CheckBox checkBox = sender as CheckBox;
        foreach(var child in ((checkBox.Parent as StackPanel).Children)) {
            if(!(child is TextBox)) {
                continue;
            }
            TextBox textBox = child as TextBox;
            if(checkBox.IsChecked.HasValue && checkBox.IsChecked.Value) {
                textBox.Visibility = Visibility.Visible;
            } else {
                textBox.Visibility = Visibility.Collapsed;
            }
        }
    }
    private void CheckBox_Checked(object sender, RoutedEventArgs e) {
        ToggleTextBoxVisibility(sender);
    }
    private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
        ToggleTextBoxVisibility(sender);
    }
