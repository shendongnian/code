    var hub = GlobalHost.ConnectionManager.GetHubContext(hubName);
    var group = hub.Clients.Group(groupName) as GroupProxy;
    if (group != null)
    {
        group.Invoke(actionName, messageData);
    }
