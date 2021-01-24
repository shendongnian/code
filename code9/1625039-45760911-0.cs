    namespace Quiz.DAL
    {
        public class QuizContext : DbContext
        {
            public QuizContext() : base("name=DefaultConnection")
            {
            }
            public virtual DbSet<Option> Options { get; set; }
            public virtual DbSet<Question> Questions { get; set; }
            public virtual DbSet<Category> Categories { get; set; }
            public virtual DbSet<Test> Tests { get; set; }
        }
    }
