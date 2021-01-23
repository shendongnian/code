       foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in resp.Data) {
            var localEntry = entry; // New line
            int rank = (int)localEntry.Rank; // entry is replaced with local
            string playerName = localEntry.UserName; 
            cell.name = playerName;
            string score = localEntry.JSONData ["SCORE"].ToString (); line 
            cell.SetScore(score);
            Debug.Log ("Rank:" + rank + " Name:" + playerName + " \n Score:" + score);
        }
