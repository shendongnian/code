    [System.Serializable]
    public class LeaderBoard
    {
        public string ID;
        public string Team;
        public string VerkoopA;
        public string VerkoopB;
        public string NPS;
        public string Conversie;
    }
    Text txt;
    IEnumerator _Start()
    {
        // Getting the leaderboard data from mySQL.
        WWW leaderboardsData = new WWW("http://localhost/leaderboards.php");
        yield return leaderboardsData;
        string leaderboardsDataString = leaderboardsData.text;
        LeaderBoard[] leaderboard = JsonHelper.FromJson<LeaderBoard>(leaderboardsDataString);
        // for every employee in the array print every employee's data.
        foreach (LeaderBoard employee in leaderboard)
        {
            DisplayLeaderboards(employee);
        }
    }
    // Display the leaderboards 1 by 1.
    void DisplayLeaderboards(LeaderBoard employeeApart)
    {
        Debug.Log("ID: " + employeeApart.ID);
        Debug.Log("Team: " + employeeApart.Team);
        Debug.Log("VerkoopA: " + employeeApart.VerkoopA);
        Debug.Log("VerkoopB: " + employeeApart.VerkoopB);
        Debug.Log("NPS: " + employeeApart.NPS);
        Debug.Log("Conversie: " + employeeApart.Conversie);
    }
