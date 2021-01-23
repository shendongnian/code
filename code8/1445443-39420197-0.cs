    var namespaceManager = NamespaceManager.CreateFromConnectionString("connectionstring");
    NotificationHubDescription hub = namespaceManager.GetNotificationHub("foo");
    hub.RegistrationTtl = TimeSpan.MaxValue;
    namespaceManager.UpdateNotificationHub(hub);
	
