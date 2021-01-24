    [Command("acceptweed")]
    public void acceptWeed(Client player, int amount, int price)
    {
        checkPlayerName = API.getPlayerName(player);
        string checkMoney = "SELECT Wallet FROM [playerInfo] WHERE PlayerName = @playerName";
        using (SqlConnection con = new SqlConnection(/* connection info */))
        using (SqlCommand command = new SqlCommand(checkMoney, con))
        {
            var playerName = new SqlParameter("playerName", SqlDbType.NVarChar);
            playerName.Value = API.getPlayerName(player);
            command.Parameters.Add(playerName);
            int playerMoney = Convert.ToInt32(checkMoneyCMD.ExecuteScalar());
        }
        if (playerMoney < price)
        {
            // It might be nice to tell the player how much money they have
            API.sendChatMessageToPlayer(player, "You don't have enough money.");
        }
        else
        {
            // Do something to subtract 'price' from 'playerMoney'
            // Also do something to subtract 'amount' from the seller's stash
            // And do something to add 'amount' to the buyer's stash
            API.sendChatMessageToPlayer(player, "You received " + amount + " of weed.");
        }
    }
