        [Command("check")]
        public async Task CheckChannel(string channel)
        {
            foreach (SocketGuildChannel chan in Context.Guild.Channels)
            {
                if (channel == chan.Name)
                {
                    // It exists!
                    ITextChannel ch = chan as ITextChannel;
                    await ch.SendMessageAsync("This is the rules channel!");
                }
                else
                {
                    // It doesn't exist!
                    await ReplyAsync($"No channel named {channel} was found.");
                }
            }
        }
