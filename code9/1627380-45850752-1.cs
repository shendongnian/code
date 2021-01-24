    var chatInfos = db.Chats
        .Where(chat => ...) // filter chats if you need to
        .SelectMany(chat =>
            // INNER JOIN with Messages, ORDER by Time, SELECT TOP 1
            chat.Messages.OrderByDescending(m => m.Time).Take(1),
            // Explicitly load Chat, LastMessage and no more than that
            (chat, msg) => new
            {
                Chat = chat,
                LastMessage = msg
            })
         // Materialize!!
         // EF will fix-up Chat-Message navigation and will know that LastMessage is in the Chat's messages collection
        .ToList()
         // Sort again, you have the last message but not the chats ordered by last message 
        .OrderByDescending(x => x.LastMessage.Time)
        // Now you have a list of chats, with last message, sorted by last message time
        .ToList();
    foreach (var info in chatInfos)
    {
        var chatEntry = db.Entry(info.Chat);
        var messageCollection = chatEntry.Collection(x => x.Messages);
        
        // Tell EF that the collection is loaded
        // Though the last query only loaded ONE Message entity via Explicit Loading
        messageCollection.IsLoaded = true;
    }
    // Get the chats, now calls to chat.Messages should not be lazy loaded for these and the collection should contain only one Message
    var chats = chatInfos.ConvertAll(x => x.Chat);
