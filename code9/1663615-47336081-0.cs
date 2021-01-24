    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public int? RightAnswerId { get; set; }
    
        [ForeignKey("Id,RightAnswerId")]
        public virtual AnswerOption RightAnswer { get; set; }
    
        public virtual ICollection<AnswerOption> AnswerOptions { get; } = new HashSet<AnswerOption>();
    }
    
    public class AnswerOption
    {       
        public int QuestionId { get; set; }
    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [InverseProperty("AnswerOptions")]
        public virtual Question Question { get; set; }
    }
    
    public class Db : DbContext
    {
        
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
    
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerOption>().HasKey(e => new { e.QuestionId, e.Id });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
