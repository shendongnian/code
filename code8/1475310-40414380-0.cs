    var hubConnection = new HubConnection(System.Configuration.ConfigurationManager.AppSettings["fwServiceAddress"].ToString());
    hubConnection.Credentials = CredentialClass.DefaultCredentials; // returns ICredentials
    IHubProxy customerHub = hubConnection.CreateHubProxy("customer");
    await hubConnection.Start();
    await customerHub.Invoke("NewNoteAdded", newNote);
