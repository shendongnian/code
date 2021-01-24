    [Command("purge", RunMode = RunMode.Async)]
    [Summary("Deletes the specified amount of messages.")]
    [RequireUserPermission(GuildPermission.Administrator)]
    [RequireBotPermission(ChannelPermission.ManageMessages)]
    public async Task PurgeChat(uint amount)
    {
    	var messages = await this.Context.Channel.GetMessagesAsync((int)amount + 1).Flatten();
    	if (!messages.Any())
    	{
    		return;
    	}
    
    	await this.Context.Channel.DeleteMessagesAsync(messages);
    	const int delay = 5000;
    	var m = await this.ReplyAsync($"Purge completed. _This message will be deleted in {delay / 1000} seconds._");
    	await Task.Delay(delay);
    	await m.DeleteAsync();
    }
