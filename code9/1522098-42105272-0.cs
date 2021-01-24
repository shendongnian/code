    // This method is what the caller sees, and abstracts the communication with the Hub
    public void NotifyGroup(string groupName, string message)
    {
      Execute("NotifyGroup", groupName, message);
    }
    // This is the method that calls the Hub
    private void Execute(string methodName, params object[] parameters)
    {
      using (var connection = new HubConnection("http://localhost/"))
      {
        _myHub = connection.CreateHubProxy("TheHub");
        connection.Start().Wait();
        _myHub.Invoke(methodName, parameters);
        connection.Stop();
      }
    }
