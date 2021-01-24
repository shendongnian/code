    [Command("Random")]
    public async Task Dice()
    {
        int value = rnd.Next(4,50);
        await ReplyAsync(Context.User.Mention + " ur random number is : " + value);
    }
