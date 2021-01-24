    public IQueryable<Team> GetTeam([FromUri] string include = "") {
    
        //If the include parameter is null the response should be 
        if(String.IsNullOrWhiteSpace(include) {
            return from c in db.Team select new Team { id = c.TeamID, name = c.teamName, logo = ""};
        }
    
         return from c in db.Team select new Team { id = c.TeamID, name = c.teamName, logo = "", social = new Map.Social { facebook = "", twitter = "" } };
    }
