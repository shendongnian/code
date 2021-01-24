    public async Task<List<Subscriber>> GetMailChimpSubscribers()
    {
        var subscribers = new List<Subscriber>();
        var listId = "";
        var members = await _manager.Members.GetAllAsync(listId);
        foreach (var item in members) //this foreach could be a simpler LinQ statement
        {
            var sub = new Subscriber();
            sub.Email = item.EmailAddress;
            subscribers.Add(sub);
        }
        return subscribers;
    }
