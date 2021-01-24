    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Initialize and show
        var dialog = new System.Windows.Forms.FolderBrowserDialog();
        System.Windows.Forms.DialogResult result = dialog.ShowDialog();
        // Process result
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            string selectedPath = dialog.SelectedPath;
            Button clickedButton = sender as Button;
            StackPanel sp = clickedButton.Parent as StackPanel;
            if (sp != null)
            {
                TextBox SelectedFolderTextBox = sp.Children.OfType<TextBox>().FirstOrDefault(x => x.Name == "SelectedFolderTextBox");
                if (SelectedFolderTextBox != null)
                    SelectedFolderTextBox.Text = selectedPath;
            }
        }
    }
