    var hub = new Microsoft.AspNet.SignalR.Client.HubConnection("http://xxxxxx/signalr/hubs");
    
    var proxy = hub.CreateHubProxy("ChatHub");
    hub.Start().Wait();
    
    //invoke hub method
    proxy.Invoke("addNewMessageToPage", "{new_ LDAP_connectivity}");
