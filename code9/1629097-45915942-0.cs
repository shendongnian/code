    public MainWindow()
    {
        InitializeComponent();
        Task.Run(() =>
        {
            while (true)
            {
                //simulate some long-running work...
                System.Threading.Thread.Sleep(1500);
                Dispatcher.BeginInvoke(new Action(() => lb.Items.Add("task x...")));
            }
        });
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Window dialog = new Window();
        dialog.ShowDialog();
    }
