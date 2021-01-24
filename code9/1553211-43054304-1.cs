    [Command("log")]
    public void login3(Client player, string passwort)
    {
        var sender = API.getPlayerName(player);
    
        using (var reader = new StreamReader(File.OpenRead(sender + ".txt")))
        {
            // use double ==
            // check if line contents equal to password, not null, because false is not null too
            if (passwort == reader.ReadLine())
            {
                API.sendChatMessageToPlayer(player, "Erfolgreich eingeloggt!");
            }
            else
            {
                API.sendChatMessageToPlayer(player, "Passwort falsch!");
            }
        }
    }
