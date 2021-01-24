    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Note>()
                    .HasMany<AppUser>(s => s.NoteAssignedToUsers )
                    .WithMany(c => c.Notes)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("AppUserId");
                                cs.MapRightKey("NoteId");
                                cs.ToTable("AppUsersNotes");
                            });
    
    }
