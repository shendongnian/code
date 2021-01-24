    public class ShowReelDB :DbContext
    {
        public ShowReelDB ():base("DefaultConnection")
        {
        }
        
        public DbSet<Tvshow> Tvshows { get; set; }
        public DbSet<EpisodeGuide> Episode { get; set; }
    }
