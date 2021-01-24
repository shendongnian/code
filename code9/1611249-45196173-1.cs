    discord.MessageReceived += async (s, e) =>
    {
        if (!e.Message.IsAuthor && e.Message.User.Id == blah)
        {
            await e.Channel.SendMessage("Yo man");
            // how do I perform command??
            ExecuteCommand();
        }
    };
