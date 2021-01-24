    _masterViewModel.Connected += delegate ()
        {
            RoutedEventArgs ea = new RoutedEventArgs(IQMasterControl.ConnectedEvent, this);
            ViewBox.RaiseEvent(ea);
        };
