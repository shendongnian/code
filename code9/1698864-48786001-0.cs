    [Command("geoff")]
    public async Task geoff()
    {
        var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "PLEB");
        await (context.User as IGuildUser).AddRoleAsync(role);
    }
