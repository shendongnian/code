    public class Matchup
    {
        public int Id { get; set; }
    
        public int WinnerId { get; set; }  // FK by convention
        public Team Winner { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
    
        public ICollection<Player> Players{ get; set; }
        public ICollection<Matchup> Matchups{ get; set; }
        public ICollection<Matchup> MatchupWinners{ get; set; }
        public ICollection<Tournament> Tournaments{ get; set; }
    }
    // Configure 1 to many
    modelBuilder.Entity<Matchup>()
        .HasOptional(m => m.Winner)
        .WithMany(p => p.MatchupWinners)
        .HasForeignKey(p => p.WinnerId);
    // Configure many to many
    modelBuilder.Entity<Matchup>()
            .HasMany(s => s.Teams)
            .WithMany(c => c.Matchups)
            .Map(t =>
                    {
                        t.MapLeftKey("MatchupId");
                        t.MapRightKey("TeamId");
                        t.ToTable("MatchupTeam");
                    });
