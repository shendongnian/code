            commands.CreateCommand("poke")
                .Parameter("target", ParameterType.Required)
                .Do(async (e) =>
                {
                    ulong id;
                    User u = null;
                    string findUser = e.Args[0];
                    if (!string.IsNullOrWhiteSpace(findUser))
                    {
                        if (e.Message.MentionedUsers.Count() == 1)
                            u = e.Message.MentionedUsers.FirstOrDefault();
                        else if (e.Server.FindUsers(findUser).Any())
                            u = e.Server.FindUsers(findUser).FirstOrDefault();
                        else if (ulong.TryParse(findUser, out id))
                            u = e.Server.GetUser(id);
                    }
                    Console.WriteLine("[" + e.Server.Name + "]" + e.User.Name + " just poked " + u);
                    await u.SendMessage("HEY, wake up! ");
                });
