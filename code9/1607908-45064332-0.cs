    public async Task<List<Subscriber>> GetMailChimpSubscribersAsync()
    {
      var subscribers = new List<Subscriber>();
      var listId = "";
      var members = await _manager.Members.GetAllAsync(listId);
      foreach (var item in members)
      {
        var sub = new Subscriber();
        sub.Email = item.EmailAddress;
        subscribers.Add(sub);
      }
      return subscribers;
    }
    public static async Task<List<Subscriber>> GetSubscribersAsync()
    {
      MailchimpHelper helper = new MailchimpHelper();
      return await helper.GetMailChimpSubscribersAsync();
    }
