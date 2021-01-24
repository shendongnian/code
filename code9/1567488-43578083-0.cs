        string usableTeamNumber = $"frc{teamNumberString}";
        string team_key = "";
        int rank = 0;
        int index = 0;
        int count = 0;
        dynamic arr = JsonConvert.DeserializeObject(rankings);
        foreach (dynamic obj in arr)
        {
            team_key = obj.team_key;
            rank = obj.rank;
            
            if (usableTeamNumber.Equals(team_key) {
                 index = count;
            }
            
            count++;
        }
        Console.WriteLine(index);
