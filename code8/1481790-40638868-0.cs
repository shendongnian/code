    private async void Treeview1_OnSelectedItemChanged(object sender,
        RoutedPropertyChangedEventArgs<object> e)
    {
        // TreeViewItem gets selected immediately.
        // Now let's do some background work, for example getting some data.
        await Task.Run(() => DoSomeBackgroundWork());
        // And fill the DataGrid with the results.
        // Thanks to async/await we're already in the dispatcher thread again.
        dataGrid.Items.Add(...);
    }
    
    private void DoSomeBackgroundWork()
    {
        // Simulate some blocking synchronous work.
        Thread.Sleep(1000);
    }
