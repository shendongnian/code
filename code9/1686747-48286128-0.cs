    [Command("say")]
    public async Task Say([Remainder] string echo)
    {
        // ReplyAsync is a method on ModuleBase
        await ReplyAsync(echo);
    }
