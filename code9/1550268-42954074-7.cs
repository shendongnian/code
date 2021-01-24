    private void comboBox1_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
    {
        if(comboBox1.SelectedItem.ToString() == "W")
        {
            listBox.DataSource= WList;
        }
        else if(comboBox1.SelectedItem.ToString() == "X")
        {
            listBox.DataSource= XList;
        }
        else if (comboBox1.SelectedItem.ToString() == "Y")
        {
            listBox.DataSource= YList;
        }
        else if (comboBox1.SelectedItem.ToString() == "Z")
        {
            listBox.DataSource= ZList;
        }
    }
