    dt = mySQL.getAsDataTable("SELECT gamenumber, date, league FROM vSpiele WHERE gamenumber LIKE '" + sgamenumber + "'", null);
    var allGames = new getGames { games = new List<Game>() };
    foreach(DataRow dr in dt.Rows)
    {                
        allGames.games.Add(new Game
        {
            gamenumber = dr["gamenumber"].ToString(),
            league = dr["league"].ToString(),
            date= dr["date"].ToString(),
        });
    }
    string json = JsonConvert.SerializeObject(allGames);
