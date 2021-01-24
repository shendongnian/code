    command.CreateCommand("echo")
                   .Description("returns commands")
                   .Parameter("message", ParameterType.Unparsed)
                   .Do(async (e) =>
                   {
                       Message[] messageToDelete;
                       int deleteNumber = 1;
                       messageToDelete = await e.Channel.DownloadMessages(deleteNumber);
                       await e.Channel.DeleteMessages(messageToDelete);
    
                       var toReturn = $":envelope: | {e.GetArg("message")}";
                       await e.Channel.SendMessage(toReturn);
                       Console.WriteLine(toReturn);
                   });
