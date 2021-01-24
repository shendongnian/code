    private void comboBox1Changed(object sender, SelectionChangedEventArgs e)
    {
        for (int i = 0; i < comboBox2.Items.Count; i++)
        {
            if ((ComboBoxItem)comboBox2.Items[i] == comboBox1.SelectedItem)
            {
               comboBox2.Items.Remove((ComboBoxItem)comboBox2.Items[i]);
            }
        }
    }
