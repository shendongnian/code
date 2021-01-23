    private readonly Dictionary<string, Connect> postponedConnectMessages = new Dictionary<string, Connect>();
    private readonly HashSet<string> actorsToBeStopped = new HashSet<string>();
    // ...
    Receive<Disconnected>(t => 
    {
        var actor = GetActorByName(t.Name);
        Context.Stop(actor);
        actorsToBeStopped.Add(actor.Path.Name);
    });
    Receive<Connected>(t =>
    {
        var actor = GetActorByName(t.Name);
        if (actorsToBeStopped.Contains(actor.Path.Name))
        {
            postponedConnectMessages[actor.Path.Name] = t;
            return;
        }
        // work with actor
    }
    Receive<Terminated>(t =>
    {
        var deadActorName = t.ActorRef.Path.Name;
        actorsToBeStopped.Remove(deadActorName);
        if (postponedConnectMessages.ContainsKey(deadActorName))
        {
            var connectMessage = postponedConnectMessages[deadActorName];
            postponedConnectMessages.Remove(deadActorName);
            var actor = GetActorByName(connectMessage.Name);
            // we sure we have new actor here
            // work with actor
        }
    }
