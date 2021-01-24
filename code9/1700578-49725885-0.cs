    [Command("check")]
    public async Task CheckChannel(string channelName)
    {
        //Makes the channel name NOT case sensitive
        var channel = Context.Guild?.Channels.FirstOrDefault(c => string.Equals(c.Name, channelName, StringComparison.OrdinalIgnoreCase));
        if (channel != null)
        {
            ITextChannel ch = channel as ITextChannel;
            await ch.SendMessageAsync("This is the rules channel!");
        }
        else
        {
            // It doesn't exist!
            await ReplyAsync($"No channel named {channel} was found.");
        }
    }
