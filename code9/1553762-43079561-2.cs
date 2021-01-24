    public void OnMessageReceived(object sender, MessageReceivedEventArgs e)
    {
        try
        {
            if (e == null)
                return;
            if (e.CmsData != null)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    this.datagrid.ItemsSource = e.CmsData.Agents.ToList();
                }));
            }
        }
    }
