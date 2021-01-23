    void disableTimer(object sender, ElapsedEventArgs e)
    {
        timer.Stop();
        timer.Enabled = false;
        Application.Current.Dispatcher.Invoke(new Action(() => ACommand.RaiseCanExecuteChanged()));
    }
