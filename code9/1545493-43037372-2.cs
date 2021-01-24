    cmd.CreateCommand("setnick")
                .Description("Changes, or sets, the nickname of the specified user.")
                .Parameter("user")
                .Parameter("newname", ParameterType.Unparsed)
                .Do(async (e) =>
            {
                var user = e.Channel.FindUsers(e.GetArg("user")).FirstOrDefault();
                string newname = e.GetArg("newname");
                await user.Edit(nickname: newname).ConfigureAwait(false);
            });
