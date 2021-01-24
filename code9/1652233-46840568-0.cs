        [Command("playing")]
        public async Task GetUsersPlaying([Remainder]string game)
        {
            int count = 0;
            for (int i = 0; i < Context.Guild.Users.Where(x => x.Game.ToString() == game).Count(); i++)
            {
                count++;
            }
            if (count > 1)
                await Context.Channel.SendMessageAsync($"There are {count.ToString()} users playing {game}.");
            else if (count == 1)
                await Context.Channel.SendMessageAsync($"There is {count.ToString()} user playing {game}.");
            else
                await Context.Channel.SendMessageAsync($"There is no one playing {game}.");
        }
