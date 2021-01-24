    [Command("timer", RunMode = RunMode.Async)] // <-- here
    [Summary("**%timer** + time in seconds and then it will tell you when it's done!")]
    private async Task test(string input)
    {   
        Int32 time = Convert.ToInt32(input);
        time *= 1000;
        await Context.Channel.SendMessageAsync(":stopwatch: **" + Context.User.Mention + "** has put a timer on **" + input + "** seconds! :stopwatch:");
        await Task.Delay(time);
        await Context.Channel.SendMessageAsync(":stopwatch: **" + Context.User.Mention + "'s** timer on **" + input + "** seconds is done! :stopwatch:");
    }
