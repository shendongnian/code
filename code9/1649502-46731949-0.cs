    void timer_Tick(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            return OrdersController.GetOrders()
        }).ContinueWith(task =>
        {
            collectionViewSource.Source = ordersList;
            DataContext = collectionViewSource;
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
