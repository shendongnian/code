    private Dictionary<Server, ChatSession> sessions = new Dictionary<Server, ChatSession>();
    
    if (sessions.Any())
    {
        if (sessions.ContainsKey(e.Server))
        {
            if(sessions[e.Server].User == e.User)
            {
                await e.Channel.SendMessage(e.User.Mention + " I'm already talking to you! :P");
                return;
            }
            else
            {
                await e.Channel.SendMessage(e.User.Mention + " I'm already talking to someone here. Try again later.");
                return;
            }
        }
        else
        {
            await e.Channel.SendMessage("This server is not stored, continuing.");
        }
    }
