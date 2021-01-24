    private static void ThreadStartPopup()
    {
        if (_popup != null && _popup.IsOpen)
            _popup.IsOpen = false;
        _popup = new AvinPopup();
        _popup.popup.VerticalOffset = System.Windows.SystemParameters.PrimaryScreenHeight - 200;
        _popup.popup.HorizontalOffset = 100; /*System.Windows.SystemParameters.PrimaryScreenWidth +100;*/
        _popup.txtPopup.Text = textPopUp;
        _popup.Show();
        StartCloseTimer();
        System.Windows.Threading.Dispatcher.Run();
    }
