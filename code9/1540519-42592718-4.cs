    private void button_Click(object sender, RoutedEventArgs e)
    {
        MultiBindingProblem probl = new MultiBindingProblem();
        probl.DataContext = new DemoRoughViewModel();
        probl.Show();
    }
