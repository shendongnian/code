        [Command("nick")]
        [Description("Change a user's nickname")]
        public async Task NicknameSet(CommandContext ctx, [Description("Nickname to change")] DiscordMember user, [Description("New name")] string nickname)
        {
            DiscordMember discordMember = user;
            var oldNick = discordMember.Nickname;
            await ctx.TriggerTypingAsync();
            try
            {
                await discordMember.ModifyAsync(x => x.Nickname = nickname);
                var newNick = discordMember.Nickname;
                await ctx.Channel.SendMessageAsync($"{ctx.Member.Username} changed {oldNick}'s nickname to: {newNick}.").ConfigureAwait(false);
                newNick = "";
            }
            catch (Exception e)
            {
                await ctx.Channel.SendMessageAsync
                    ($"An error occured: {e}").ConfigureAwait(false);
            }
        }
