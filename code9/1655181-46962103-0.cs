    public class Data
    {
        public int Id { get; set; }
    
        public int LeagueId { get; set; }
        [ForeignKey("LeagueId")] /* Add explicit foreign key data annotations */
        public League League { get; set; }
    
        public int HomeTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }
    
        public int AwayTeamId { get; set; }
        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }
    }
    public class Team
    {
        public Team()
        {
            this.HomeTeamData = new HashSet<Data>();
            this.AwayTeamData = new HashSet<Data>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Data> HomeTeamData { get; set; }
        public virtual ICollection<Data> AwayTeamData { get; set; }
    }
