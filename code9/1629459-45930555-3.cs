    modelBuilder.Entity<JOBLINE>()
        .Property(p => p.LineType)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_LineTypeAndLineCode") { IsUnique = true, Order = 1 }));
    modelBuilder.Entity<JOBLINE>()
        .Property(p => p.LineCode)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_LineTypeAndLineCode") { IsUnique = true, Order = 2 }));
