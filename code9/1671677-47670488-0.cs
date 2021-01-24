    private void Button_Click(object sender, RoutedEventArgs e)
    {
     OpenFileDialog ofd = new OpenFileDialog();
    ofd.Filter = "CSV|*.csv";
    ofd.ShowDialog();
    csvName.Text = ofd.FileName;           
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
    using(var reader = new StreamReader(csvName.Text))
    {
    // do your action here
    }
    }
