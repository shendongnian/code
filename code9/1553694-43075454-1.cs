    if (e.CmsData != null)
    {
        string text = string.Join(Environment.NewLine, 
                                 e.CmsData.Agents.Select(item => item.AuxReasonDescription));
        Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
        {
            textBlock.Text = text;                   
        }
    }
