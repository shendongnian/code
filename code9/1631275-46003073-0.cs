    private void Submit_Click(object sender, RoutedEventArgs e)
    {
        var test = new test();
        test.TName.Text = this.TIName.Text;
        this.Close();
        test.Show();
    }
