    [Command("Test")]
                public async Task Test(string message)
                {
                    if (message== "Send me a message")
                    {
                        
                        await Context.User.SendMessageAsync("Here is your DM message! ;)");
                    }else
                    {
                        await Context.Channel.SendMessageAsync("I can't send you a message");
                    }
                }
