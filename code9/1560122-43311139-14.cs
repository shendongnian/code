    var factory = new CommandFactory("http://localhost:4200/person/");
    var commandsToExecute = new List<PersonCommand>();
    
    commandsToExecute.Add(factory.Create("add", new Person { Name = "asd", State = "CA" }));
    
    commandsToExecute.Add(factory.Create("update", new Person { Name = "barry", State = "CA" }));
    
    commandsToExecute.Add(factory.Create("delete", new Person { Name = "barry", State = "CA" }));
    
    commandsToExecute.ForEach(cmd => cmd.Apply());
