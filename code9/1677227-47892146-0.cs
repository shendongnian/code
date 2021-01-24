    var hubConnection = new HubConnection("http://localhost/SignalRHost/signalr");
    IHubProxy myHub = hubConnection.CreateHubProxy("MyHub");
    await hubConnection.Start();
    myHub.Invoke("JoinGroup", "theGroupName");
    myHub.Invoke("Notify", "theGroupName", "My beautifull message.");
