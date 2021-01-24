    public virtual DBSet<AspNetUserPreference> AspNetUserPreferences { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<AspNetUserPreferences>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
