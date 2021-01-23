    // Delete the db private field and use local variable.
    using (var db = new ApplicationDataContext()) 
    {
        db.Users.Attach(user); // Let the context know about the current user.
        ChatMessage chatMessage = new ChatMessage();
        Grouppe grouppe = new Grouppe ();
        grouppe.GrouppeID = 4;
        chatMessage.ChatMessageOwner = user;
        chatMessage.ChatMessageText = "Test";
        chatMessage.ChatMessageTime = DateTime.Now;
        chatMessage.Grouppe = grouppe; // Side note: here set the navigational property directly.
 
        db.ChatMessage.Add(chatMessage);
        await db.SaveChangesAsync();
    }
