    public TestViewModel()
    {
        ViewModelList = new ObservableCollection<TestModel>();
    
        ViewModelList.Add(new TestModel { ShowText = "this is first test" });
        ViewModelList.Add(new TestModel { ShowText = "this is second test" });
        ViewModelList.Add(new TestModel { ShowText = "this is third test" });
        //Create a timer to update the data source.
        var dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Tick += dispatcherTimer_Tick;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        dispatcherTimer.Start();
    }
    
    private void dispatcherTimer_Tick(object sender, object e)
    {
        ViewModelList.Add(new Models.TestModel() { ShowText = "this is the added item" });
    }
