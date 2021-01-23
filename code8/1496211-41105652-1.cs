    private void OnGoClick(object sender, RoutedEventArgs e)
    {
        loadingGif.Visibility = Visibility.Visible;
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += OnDoWork;
        worker.RunWorkerCompleted += OnRunWorkerCompleted;
        worker.RunWorkerAsync();
    }
    private void OnDoWork(object o, DoWorkEventArgs args)
    {
        Task.Delay(2000).Wait(); // Pretend to work
    }
    private void OnRunWorkerCompleted(object o, RunWorkerCompletedEventArgs args)
    {
        loadingGif.Visibility = Visibility.Hidden;
    }
