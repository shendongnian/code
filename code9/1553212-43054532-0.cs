    [Command("log")]
    public void login3(Client player, string passwort)
    {
        //DONE: validate public method's arguments
        if (null == player) 
          throw new ArgumentNullException("player");
        else if (String.IsNullOrEmpty(password)) 
          return; // Player doesn't have a password
    
        // Read the first line of the file and compare it with the password 
        if (File
              .ReadLine(player + ".txt") //TODO: implement as a property: player.FileName
              .Take(1)
              .Any(line => line == passwort)) 
          API.sendChatMessageToPlayer(player, "Erfolgreich eingeloggt!");
        else
          API.sendChatMessageToPlayer(player, "Passwort falsch!");
    }
