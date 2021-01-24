        [Command("purge")]
        [Name("purge <amount>")]
        [Summary("Deletes a specified amount of messages")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task DelMesAsync(int delnum)
        {
            var items = await Context.Channel.GetMessagesAsync(delnum + 1).Flatten();
            await Context.Channel.DeleteMessagesAsync(items);
        }
