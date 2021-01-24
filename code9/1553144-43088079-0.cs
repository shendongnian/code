    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public virtual TeamMember TeamMember { get; set; }
    }
    public partial class TeamMember
    {
        [Key, ForeignKey("User")]
        public Guid Id{ get; set; }
        public virtual User User { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)  
    {  
        modelBuilder.Entity<TeamMember>()
                    .HasRequired(p => p.User)
                    .WithOptional(p => p.TeamMember);
    } 
