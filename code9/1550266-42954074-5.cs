    private void comboBox1_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
    {
        if(comboBox.SelectedItem.ToString() == "W")
        {
            listBox.DataSource= WList;
        }
        else if(comboBox.SelectedItem.ToString() == "X")
        {
            listBox.DataSource= XList;
        }
        else if (comboBox.SelectedItem.ToString() == "Y")
        {
            listBox.DataSource= YList;
        }
        else if (comboBox.SelectedItem.ToString() == "Z")
        {
            listBox.DataSource= ZList;
        }
    }
