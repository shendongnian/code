    private void button_Click(object sender, RoutedEventArgs e)
    {
        MainWindow p = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        if (p != null)
            p.Aktualizuj();
        this.Close();
    }
