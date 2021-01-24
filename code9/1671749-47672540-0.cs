    var message = await ReplyAsync("abc");
    await message.ModifyAsync(x =>
    {
        x.Content = "";
        x.Embed = new EmbedBuilder()
            .WithColor(new Color(40, 40, 120))
            .WithAuthor(a => a.Name = "foxbot")
            .WithTitle("Embed!")
            .WithDescription("This is an embed.")
            .Build(); //<-- The is what was omitted.
    });
