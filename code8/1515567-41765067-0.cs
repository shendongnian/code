    client.UsingCommands(input =>
                {
                    input.PrefixChar = '!';              // the prefix char to call commands
                    input.AllowMentionPrefix = true;
                });
