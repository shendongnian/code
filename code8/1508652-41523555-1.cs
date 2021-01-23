    while (true) {
      var  updates = await bot.MakeRequestAsync(new GetUpdates() { Offset = offset });
      foreach(var update in updates) {
        var sender = GetSender(update);
        var game = RetrieveGameOrInit(sender);
        
        // ... rest of your processing, but your code is a little messy and
        // you have to figure out how to refactor the processing by yourself
        game.Update(update);
        // do something with game, and possibly remove it if it's over.
      }
    }
    public string GetSender(UpdateResponseOrSomething update)
    {
        // use the Telegram API to find a key to uniquely identify the sender of the message.
        // the string returned should be the unique identifier and it
        // could be an instance of another type, depending upon Telegram
        // API implementation: e.g. an int, or a Guid.
    }
    private Dictionary<string, Game> _runningGamesCache = new Dictionary<string, Game>();
    public Game RetrieveGameOrInit(string senderId)
    {
        if (!_runningGamesCache.ContainsKey(senderId))
        {
           _runningGamesCache[senderId] = InitGameForSender(senderId);
        }
        return _runningGamesCache[senderId];
    }
    /// Game.cs
    public class Game
    {
      public string SenderId { get; set; }
      public string DesiredWord { get; set; }
      // ... etc
      public void Update(UpdateResponseOrSomething update)
      {
        // manage the update of the game, as in your code.
      }
    }
