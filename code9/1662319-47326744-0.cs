    private static DispatcherTimer _popUpOpeningTimer = new DispatcherTimer();
    
    void DisplayPopUpOnMouseEnter(object sender, MouseEventArgs e)
    {
        // if we do not have DispatcherTimer set then only initialize it 
        if (_popUpOpeningTimer == null)
        {
              _popUpOpeningTimer = new DispatcherTimer();
        }
        else // this means that dispatcher timer is already initialized, so do nothing
        {
             // do nothing
        }
        // stop the timer if it is already set so that we can start new timer
        _popUpOpeningTimer.Stop();
    
        _popUpOpeningTimer.Interval = new TimeSpan(0, 0, 1);
    
        _popUpOpeningTimer.Tick += new EventHandler((senderObject, eventArguments) => DisplayPopUp(senderObject, eventArguments, btnDisplayPopUp));
    
        // start the timer for opening the details popup
        _popUpOpeningTimer.Start();  
    }
    
    private void DisplayPopUp(object sender, EventArgs e, Button button)
    {
        if(button.IsMouseOver)
        {
             spPinDetailsPopup.Visibility = Visibility.Visible;
        }
        else
        {
             // do nothing
        }
    }
