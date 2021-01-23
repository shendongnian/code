    CommandStrategy strategy = new CommandStrategy();
            
    List<CommandBase> commands = new List<CommandBase>(){
                      new Command1(), new Command2(), new Command3() };
    foreach (var item in commands)
    {
       CommandTypes type = (CommandTypes)item;
       strategy.Execute(type);
    }
    
