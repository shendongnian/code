     public MyView(MyViewModel vm)
            {
                InitializeComponent();
    
                Progress.StartAnimation();
    
                Task.Run(() =>
                {
                    var dataContext = DataContext as MyViewModel;
                    while (true)
                    {
                        if (dataContext.IsLoadComplete)
                            break;
                        Task.Delay(100);
                    }
                    Dispatcher.BeginInvoke(new Action(() => { Progress.StopAnimation(); }));
                });
            }
