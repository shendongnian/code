    command.CreateCommand("say").Parameter("message", ParameterType.Multiple).Do( async (e) = > 
    {
      string message = "";
      for (int i = 0; i < e.Args.Length; i++) 
      {
        message += e.Args[i].ToString() + " ";
      }
      await e.Channel.SendMessage(message);
    }
