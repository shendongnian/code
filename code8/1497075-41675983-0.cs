        private void RegisterShutdownCommand()
    {
        commands.CreateCommand("exit")
            .Do((e) =>
                {
                    if (e.User.Id != <Your_User_ID>)
    				{
    					/*Code to execute when its not the owner.*/
    				}
    				else
    				{
    					Environment.Exit(0);
    				}
                });
    
    }
