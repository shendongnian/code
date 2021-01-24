    public void NotifyGroup(string groupName, string message)
    {
      var group = Clients.Group(groupName);
      if (group == null)
      {
        Log.IfWarn(() => $"Group '{groupName}' is not registered");
        return;
      }
      group.NotifyGroup(message);
    }
