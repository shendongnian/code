    public P3()
    {
        this.InitializeComponent();
        Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
    }
    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        if (F2 == null)
            return;
        // Navigate back if possible, and if the event has not 
        // already been handled .
        if (F2.CanGoBack && e.Handled == false)
        {
            e.Handled = true;
            F2.GoBack();
        }
    }
