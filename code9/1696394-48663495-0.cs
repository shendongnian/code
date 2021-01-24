    var timer = new DispatcherTimer
        (
        TimeSpan.FromMinutes(10),
        DispatcherPriority.ApplicationIdle,// Or DispatcherPriority.SystemIdle
        (s, e) => MessageBox.Show("Timer"),
        Application.Current.Dispatcher
        );
