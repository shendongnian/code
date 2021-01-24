    [Command("geoff")]
    public async Task geoff(IUser user)
    {
        var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "PLEB");
        await (user as IGuildUser).AddRoleAsync(role);
    }&#xD;
