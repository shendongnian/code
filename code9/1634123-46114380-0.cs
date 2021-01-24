    public class Context : DbContext
    {
        public Context() : base()
        {
            
        }
        public IDbSet<Translation> Translations { get; set; }
        public IDbSet<TranslatedModel> TranslationModels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Stores");
                });
            modelBuilder.Entity<Publisher>().Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("Publishers");
                });
            modelBuilder.Entity<Translation>()
                .HasRequired(t => t.TranslatedModel)
                .WithRequiredDependent(t => t.Translation);
        }
    }
    public class Translation
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public TranslatedModel TranslatedModel { get; set; }
    }
    public abstract class TranslatedModel
    {
        public int Id { get; set; }
        public Translation Translation { get; set; }
    }
    public class Store : TranslatedModel
    {
        public int Website { get; set; }
    }
    public class Publisher : TranslatedModel
    {
        public string Website { get; set; }
    }
