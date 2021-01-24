    public virtual IDbSet<AppTables.Programs.Program> Programs { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            modelBuilder.Entity<AppTables.Programs.Program>()
                    .HasOptional(m => m.MainSubject)
                    .WithMany(t => t.ProgramsMain)
                    .HasForeignKey(m => m.MainContactSubjectId)
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<AppTables.Programs.Program>()
                    .HasOptional(m => m.SecondarySubject)
                    .WithMany(t => t.ProgramsSecondary)
                    .HasForeignKey(m => m.SecondaryContactSubjectId)
                    .WillCascadeOnDelete(false);
    }
