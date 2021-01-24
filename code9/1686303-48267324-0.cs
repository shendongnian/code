    void timer_Tick(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            return OrdersController.getAllOrders();
        })
        .ContinueWith(task =>
        {
            if (task.Exception != null)
            {
                MessageBox.Show(ask.Exception.Message);
            }
            else
            {
                collectionViewSource.Source = task.Result;
                DataContext = collectionViewSource;
            }
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
