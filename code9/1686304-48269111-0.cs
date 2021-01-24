    private async void timer_Tick(object sender, EventArgs e)
    {
        try
        {
            var ordersList = await Task.Run(() => OrdersController.getAllOrders());
            collectionViewSource.Source = ordersList;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
