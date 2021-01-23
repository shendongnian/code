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
