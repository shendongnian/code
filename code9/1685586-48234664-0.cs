    [Command("timer", RunMode = RunMode.Async)] // <-- here
    [Summary("**%timer** + time in seconds and then it will tell you when it's done!")]
    private async Task test(string input)
    {   
        //something like this
        User user = Context.User;
        string name = Context.User.Username;
        Int32 time = Convert.ToInt32(input);
        time *= 1000;
        await Context.Channel.SendMessageAsync(":stopwatch: **" + name + "** has put a timer on **" + input + "** seconds! :stopwatch:");
        await Task.Delay(time);
        await Context.Channel.SendMessageAsync(":stopwatch: **" + user + "'s** timer on **" + input + "** seconds is done! :stopwatch:");
    }
