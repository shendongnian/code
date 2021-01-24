    commands.CreateCommand("sarcastify")
        .Parameter("input",ParameterType.Multiple)
        .Do(async (e) =>
        {
            String userInput = string.Join(" ", e.Args);
            String output = sarcastify(userInput);
            await e.Channel.SendMessage(output);               
        });
