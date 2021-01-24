    public class LectureCompletion
    {
        // which is your case.
        [ForeignKey("Lecture")] 
        public int LectureId { get;set; }
        public Lecture Lecture { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId {get;set;}
        public ApplicationUser ApplicationUser { get; set; }
        public bool Completed { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
         base.OnModelCreating(builder);
         // Define composite key.
         builder.Entity<LectureCompletion>()
             .HasKey(lc => new { lc.LectureId, lc.UserId });
    }
