    public MainViewModel()
    {
       // Move this into the constructor to avoid any race conditions
       _wlg = new WellListGroup {headers = headers, selected = headers[0]};
    
      // Subscribe to the property change even for WLG
       _wlg.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == 'selected')
                        OnChange()// do stuff!!!
                };
    }
