    List<LeaderboardRow> leaderboardList = new List<LeaderboardRow>();
    StreamReader srUserData = new StreamReader(@"User Leaderboard.txt");
    while ((userDataLine = srUserData.ReadLine()) != null)
    {
        //Put logic here that parses your string row into 3 distinct values
        leaderboardList.Add(new LeaderboardRow()
        {
            Score = 0, //put real value here
            Name = string.Empty, //put real value here
            Difficulty = string.Empty //put real value here
        });
    }
