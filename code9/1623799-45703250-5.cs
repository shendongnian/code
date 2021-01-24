    public string OppositeColor(string color)
    {
        //No need to check if key exists
        return _oppositesDictionary[color];
    }
    private void button_Click(object sender, RoutedEventArgs e)
    {
        string color = cboColors.SelectedItem.ToString();
        MessageBox.Show(OppositeColor(color));
    }
