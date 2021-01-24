    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(comboBox.SelectedItem.ToString() == "W")
        {
            listBox.ItemsSource = WList;
        }
        else if(comboBox.SelectedItem.ToString() == "X")
        {
            listBox.ItemsSource = XList;
        }
        else if (comboBox.SelectedItem.ToString() == "Y")
        {
            listBox.ItemsSource = YList;
        }
        else if (comboBox.SelectedItem.ToString() == "Z")
        {
            listBox.ItemsSource = ZList;
        }
    }
