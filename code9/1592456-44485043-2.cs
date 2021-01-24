    commands.CreateCommand("joke")
        .Do(async e =>
        {
            var id = e.ChannelId; // example using channel id as unique key
            var nowUtc = DateTimeOffset.UtcNow;
            var canReturnJoke = true;
            UsersJokesLastCall.AddOrUpdate(id, nowUtc, (key, oldValue) =>
            {
                var elapsed = nowUtc - oldValue; // check elapsed time
                if(elapsed.TotalSeconds < 100)
                {
                    canReturnJoke = false; // min time has not passed
                    return oldValue; // do not change the last joke time
                }
                return nowUtc; // update to current time
            });
            
            if(!canReturnJoke)
            {
                // return something to the user
                await e.Channel.SendMessage("Try later");
                return;
            }
            jokeNumber = jokeNumber + 1;
            if (jokeNumber.Equals(3))
            {
                jokeNumber = 0;
            }
            else
            {
                jokeNumber = jokeNumber + 0;
            }
            string jokePost = joke[jokeNumber];
            await e.Channel.SendMessage(jokePost);
        });
