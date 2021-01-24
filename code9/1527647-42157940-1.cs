    void Global_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "ActiveMessage":
                lock (lockActualMessages)
                {
                    this.ActualMessages.Clear();
                    if (Global.ActualMessages != null)
                    {
                        foreach (var message in Global.ActualMessages)
                            this.ActualMessages.Add(message);
                    }
                }
                break;
        }
    }
