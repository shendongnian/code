    Commands2 commands = (Commands2)_applicationObject.Commands;
    object[] contextGUIDS = new object[] { };
    CommandBars cmdBars = (CommandBars)(_applicationObject.CommandBars);
    CommandBar vsBarProject = cmdBars["Code Window"];
    
    scenarioCommand = commands.AddNamedCommand2(_addInInstance, "OpenScenario", "Open scenario", "Open scenario data", true);
    scenarioCommand.AddControl(vsBarProject);
