    public String ConnectToServer(string whereClauseParam)
    {
        //Create Server object here
        Server s = new Server();
        s.AttachedServiceStatus += OnAttachedServiceStatus;
        s.AttachService(this, whereClauseParam, 8799989);
    }
    public void OnAttachedServiceStatus (object sender, ClientServiceAttachedEventArgs e)
    {
        if (e.AttachStatus == AttachedStatus.Connected && e.ServiceAttachStatus == ServiceAttachStatus.Attached)
        { 
            // Update the UI with the message from the server.
            MessageBox.Show(e.Message);
            // If you need to do something else with the server in response, you can do this:
            ((Server)sender).Foo("bar");
        }
    }
