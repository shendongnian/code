    private string selected;
    public string Selected
    {
        get { return selected; }
        set
        {
            if (selected != value)
            {
                //  Don't let them select "B". 
                if (value == "B")
                {
                    Dispatcher.CurrentDispatcher.
                        BeginInvoke(new Action(() => this.Selected = "C"),
                                    DispatcherPriority.ApplicationIdle);
                    return;
                }
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
    }
