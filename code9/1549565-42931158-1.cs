    private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        listBox.Items.Clear();
        if(comboBox.SelectedItem.ToString() == "Computer Science")
        {
            listBox.Items.Add(File.ReadAllText(ComputerScienceFile));
        }
        else if(comboBox.SelectedItem.ToString() == "Mathematics")
        {
            listBox.Items.Add(File.ReadAllText(MathematicsFile));
        }
    }
