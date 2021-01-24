    var dispatcherTimer = new DispatcherTimer();
    dispatcherTimer.Tick += CheckEffectExpiry;
    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
    dispatcherTimer.Start();
    //...
    void CheckEffectExpiry(object sender, object e)
    {
        switch (UIViewSettings.GetForCurrentView().UserInteractionMode)
        {
            case UserInteractionMode.Mouse:
                debugBox.Text = "mouse";
                break;
            default:
                debugBox.Text = "tablet";
                break;
        }
    }
