    private void comboBox_SelectionChanged_1(object sender,
    	System.Windows.Controls.SelectionChangedEventArgs e)
    {
    	string content = ((ComboBoxItem)comboBox.SelectedItem).Content as string;
    	if (content != null)
    		MessageBox.Show(content);
    }
