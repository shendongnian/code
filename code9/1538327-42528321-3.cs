    public HtmlCommunicator communicator { get; set; }
    private void Control_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
    {
        if (Control != null && Element != null)
        {
            communicator = new HtmlCommunicator();
            Control.AddWebAllowedObject("HtmlCommunicator", communicator);
        }
    }
