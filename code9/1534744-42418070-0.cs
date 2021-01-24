    commandManager.CommandsByName["InteractionVoiceReleaseCall"].Insert(0, new CommandActivator()
                {
                    CommandType = typeof(CustomCommand.ReleaseCall),
                    Name = "InteractionVoiceReleaseCall"
                });     
