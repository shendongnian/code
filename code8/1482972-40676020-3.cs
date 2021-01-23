    dt = mySQL.getAsDataTable("SELECT gamenumber, date, league FROM vSpiele 
                               WHERE gamenumber LIKE '" + sgamenumber + "'", null);
    var getGames = new getGames(); 
    getGames.games = new List<Game>();
    foreach(DataRow row in dt.Rows)
    {
       getGames.games.Add(new Game(){
          gamenumber = row["gamenumber"].ToString(),
          league = row["league"].ToString(),
          date= row["date"].ToString()
       });
    }
    string json = JsonConvert.SerializeObject(getSpiele);
