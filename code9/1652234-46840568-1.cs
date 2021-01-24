        [Command("playing")]
        public async Task GetUsersPlaying([Remainder]string game)
        {
            await Context.Message.DeleteAsync();
            int count = 0;
            List<string> UserList = new List<string>();
            var UsersPlayingGame = Context.Guild.Users.Where(x => x.Game.ToString() == game).Distinct();
            foreach (var pUser in UsersPlayingGame)
            {
                count++;
                UserList.Add(pUser.Username);
            }
            if (count > 1)
                await Context.Channel.SendMessageAsync($"There are {count.ToString()} users playing {game}. [{string.Join(", ", UserList)}]");
            else if (count == 1)
                await Context.Channel.SendMessageAsync($"There is {count.ToString()} user playing {game}. [{string.Join(", ", UserList)}]");
            else
                await Context.Channel.SendMessageAsync($"There is no one playing {game}.");
        }
