        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<StatsBySeason>();
            // ...
        }
    or data annotation:
        [NotMapped]
        public class StatsBySeason : StatLines
        {
            // ...
        }
