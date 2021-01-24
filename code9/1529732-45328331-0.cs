    public ActionResult RegisterConnectionId(string newConnectionId, string oldConnectionId)
    {
        Session["SignalRConnectionId"] = newConnectionId;
        if(!string.IsNullOrEmpty(oldConnectionId))
            RemapConnectionId(newConnectionId, oldConnectionId);        
    }
