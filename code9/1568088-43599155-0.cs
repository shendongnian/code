    [Command("acceptweed")]
    public void acceptWeed(Client player, int amount, int price)
    {
        checkPlayerName = API.getPlayerName(player);
        string checkMoney = "SELECT Wallet FROM [playerInfo] WHERE PlayerName='" + 
            checkPlayerName + "'";
        con.Open();
        SqlCommand checkMoneyCMD = new SqlCommand(checkMoney, con);
        int playerMoney = Convert.ToInt32(checkMoneyCMD.ExecuteScalar());
        con.Close();
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
