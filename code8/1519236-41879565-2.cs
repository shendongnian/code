    public event EventHandler<ClientServiceAttachedEventArgs> AttachedServiceStatus;
    public String AttachService(Client client, string whereClauseParam, int code)
    {
        // Do what you need to do to register the client.
        //...
        // Assuming everything went as planned, fire the event.
        // First, construct the EventArgs with information about the results of the connection.
        ClientServiceAttachedEventArgs e = new ClientServiceAttachedEventArgs();
        e.AttachStatus = AttachedStatus.Connected;
        e.ServiceAttachStatus = ServiceAttachStatus.Attached;
        e.Message = "Attached";
        // This is where your OnAttachedServiceStatus method in the client finally gets called. If the event handler were returning a string, this is where it would be returned to and I can't imagine this does you any good. 
        AttachedServiceStatus(this, e); 
    }
