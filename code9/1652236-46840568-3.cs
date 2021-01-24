        [Command("playing")]
        public async Task GetUsersPlaying([Remainder]string game)
        {
            await Context.Message.DeleteAsync();
            var users = Context.Guild.Users.Where(x => x.Game.ToString() == game).Distinct().Select(x => x.Username);
            var count = users.Count();
            var SeparatedList = string.Join(", ", users);
            string message;
            if (count > 1)
                message = $"There are {count} users playing {game}. [{SeparatedList}]";
            else if (count == 1)
               message = $"There is {count} user playing {game}. [{SeparatedList}]";
            else
                message = $"There is no one playing {game}.";
            await  Context.Channel.SendMessageAsync(message);
        }
