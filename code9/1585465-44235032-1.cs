    private static readonly ManualResetEventSlim _Blocker = new ManualResetEventSlim(false);
    private static void ThreadStartPopup()
    {
        _Blocker.Reset();
        System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
        {
            if (_popup != null && _popup.IsOpen)
                _popup.IsOpen = false;
             _Blocker.Set();
        }));
        _Blocker.Wait();
        _popup = new AvinPopup();
        _popup.popup.VerticalOffset = System.Windows.SystemParameters.PrimaryScreenHeight - 200;
        _popup.popup.HorizontalOffset = 100; /*System.Windows.SystemParameters.PrimaryScreenWidth +100;*/
        _popup.txtPopup.Text = textPopUp;
        _popup.Show();
        StartCloseTimer();
        System.Windows.Threading.Dispatcher.Run();
    }
