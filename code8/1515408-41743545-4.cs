    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SkillSet>()
                    .HasMany<Candidate>(s => s.Candidates)
                    .WithMany(c => c.SkillSets)
                    .Map(cs =>
                    {
                        cs.MapLeftKey("SkillSetId");
                        cs.MapRightKey("CandidateId");
                        cs.ToTable("candidate_skillset");
                    });
        modelBuilder.Entity<SkillSet>().ToTable("skillset");
        modelBuilder.Entity<Candidate>().ToTable("candidate");
    }
