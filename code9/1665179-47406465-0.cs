    builder.Entity<SemesterSubject>(entity =>
    {
        entity.HasOne(e => e.semesters)
            .WithMany(e => e.Semestersubjects)
            .HasForeignKey(e => e.semesterId)
            .OnDelete(DeleteBehavior.Restrict);
    });
