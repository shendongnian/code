    public void UpdateUI(object parameter)
    {
        if (this.InvokeRequired)
        {
           Dispatcher.BeginInvoke(new Action(() => UpdateUI(parameter)));
            return;
        }
        // Update or access here 
    }
