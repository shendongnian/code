    var Connection = new HubConnection("yourSignalRServerUrl");      
    var HubProxy = Connection.CreateHubProxy("OpenHub"); 
    HubProxy.On<string>("RecieveNewInfo", (message) => 
        this.Invoke((Action)(() => 
          Form1.lstMessages.Add(message);
    );
    await Connection.Start(); 
