    _client.GetService<CommandService>().CreateGroup("user", cgb =>
            {
                cgb.CreateCommand("kick")
                    .Description("Kick a user from the Server.")
                    .Parameter("User", ParameterType.Required)
                    .AddCheck((command, user, channel) => !paused)
                    .Do(async e =>
                    {
                        try
                        {
                            if (e.User.ServerPermissions.KickMembers)
                            {
                                User user = null;
                                try
                                {
                                    // try to find the user
                                    user = e.Server.FindUsers(e.GetArg("User")).First();
                                }
                                catch (InvalidOperationException)
                                {
                                    await e.Channel.SendMessage($"Couldn't kick user {e.GetArg("User")} (not found).");
                                    return;
                                }
                                // double safety check
                                if (user == null) await e.Channel.SendMessage($"Couldn't kick user {e.GetArg("User")} (not found).");
                                await user.Kick();
                                await e.Channel.SendMessage($"{user.Name} was kicked from the server!");
                            }
                            else
                            {
                                await e.Channel.SendMessage($"{e.User.Name} you don't have the permission to kick.");
                            }
                        }
                        catch (Exception ex)
                        {
                            // needs a better error handling haven't changed it since i tested it xD
                            await e.Channel.SendMessage(ex.Message);
                        }
                    });
