        public partial class UploadsDataModelContainer : DbContext
    {
        public virtual DbSet<Chunk> CHunks { get; set; }
        public virtual DbSet<Upload> Uploads { get; set; }
    }
