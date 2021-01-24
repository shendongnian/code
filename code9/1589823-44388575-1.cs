    private void button1_Click(object sender, EventArgs e)
    {
        var api = RiotApi.GetInstance("KEY");
        GameType game = new GameType();        
        try
        {
            game = api.GetCurrentGame(RiotSharp.Platform.EUW1, 79200188);
        }
        catch (RiotSharpException ex)
        {
            throw;
        }
        if(game == null || !game.Participants.Any()) return;
        foreach (var player in game.Participants) // Can't find game variable
        {
        }
    }
