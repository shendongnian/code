    public class Team
    {
        public Team()
        {
            teamGuid = "I have a value!";
            teamName = "me too!";
        }
        public Team(CompanyTeam company) : this()
        {
            this.company = company;
        }
        public string teamGuid { get; set; }
        public string teamName { get; set; }
        public CompanyTeam company { get; set; }
        public dynamic GetSerializeInfo() => new
        {
            teamGuid,
            teamName,
            company = company ?? new object()
        };
    }
