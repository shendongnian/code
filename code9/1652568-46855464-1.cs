    public class Team
    {
        public int Id { get; set; }
    
        public ICollection<Player> Players{ get; set; }
        [InverseProperty("Teams")]
        public ICollection<Matchup> Matchups{ get; set; }
        [InverseProperty("Winner")]
        public ICollection<Matchup> MatchupWinners{ get; set; }
        public ICollection<Tournament> Tournaments{ get; set; }
    }
