    var mcs = (OleMenuCommandService) GetService(typeof(IMenuCommandService));
    var commandId = new CommandID(typeof(YourAddinCommand).GUID, (int)YourAddinCommand.MyCommand));
    mcs.AddCommand(new MenuCommand(delegate {
    	MessageBox.Show("You clicked me!");
    }, commandId);
