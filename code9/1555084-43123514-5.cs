    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (comboBox.SelectedItem.ToString() == "Planning")
        {
            comboBox.Background = Brushes.Purple;
        }
        else if (comboBox.SelectedItem.ToString() == "Progress")
        {
            comboBox.Background = Brushes.Blue;
        }
        else if (comboBox.SelectedItem.ToString() == "Done")
        {
            comboBox.Background = Brushes.Green;
        }
    }
