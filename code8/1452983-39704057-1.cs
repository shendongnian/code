    return Chain.ContinueWith(new GreetingDialog(), AfterGreetingContinuation);
    private async static Task<IDialog<string>> AfterGreetingContinuation(IBotContext context, IAwaitable<object> res)
    {
        var token = await res;
        var name = "User";
        context.UserData.TryGetValue<string>("Name", out name);
        return Chain.Return($"You are logged in as: {name}");
    }
