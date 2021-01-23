    public TableViewCell GetCellForRowInTableView (TableView tableView, int row)
    {
        LeaderboardCell cell = tableView.GetReusableCell (m_cellPrefab.reuseIdentifier) as LeaderboardCell;
    
        if (cell == null) {
            cell = (LeaderboardCell)GameObject.Instantiate (m_cellPrefab);
            new GameSparks.Api.Requests.LeaderboardDataRequest ().SetLeaderboardShortCode ("High_Score_Leaderboard").SetEntryCount (100).Send ((response) => {
                if (!response.HasErrors) {
                    resp = response;
                    Debug.Log ("Found Leaderboard Data...");
    
                } else {
                    Debug.Log ("Error Retrieving Leaderboard Data...");
                }
            });
        }
    
        var entry = resp.Data[row];
            int rank = (int)entry.Rank;
            //model.Rank =rank;
            string playerName = entry.UserName;
            cell.name = playerName;
            string score = entry.JSONData ["SCORE"].ToString ();
            cell.SetScore(score);
            //string fbid = entry.ExternalIds.GetString("FB").ToString();
            //model.facebookId = fbid;
            Debug.Log ("Rank:" + rank + " Name:" + playerName + " \n Score:" + score);
        
        return cell;
    }
