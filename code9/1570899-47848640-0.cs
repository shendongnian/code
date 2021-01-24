    [Command("spam")]
    [RequireUserPermission(GuildPermission.Administrator)]
    public async Task CMD14(int times, [Remainder] string Word)
    {
        for (int i = 0; i < times; i++)
        {
            await Context.Channel.SendMessageAsync($"`{Word}`");
        }
    }
