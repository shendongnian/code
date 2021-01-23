    //creating cols in UI thread
    var cols = new List<DataGridColumn>
    {
        new DataGridTextColumn {Header = "test col 1", Binding = new Binding()},
        new DataGridTextColumn {Header = "test col 2", Binding = new Binding()}
    };
    
    await Task.Delay(1).ConfigureAwait(false);    //detaching to thread pool thread
    
    ViewModel.Columns = new ObservableCollection<DataGridColumn>(); //initializing colleciton in thread pool
    
    Dispatcher.Invoke(() => { },DispatcherPriority.ApplicationIdle);  //wait for dispatched PropertyChanged to take effect
    
    //adding previously created columns - should succeed
    foreach (var dataGridColumn in cols)
        ViewModel.Columns.Add(dataGridColumn);
