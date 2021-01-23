    string uniqueIndex = "UQ_Registration_EventId_ParticipantId";
    modelBuilder.Entity<Registration>().Property(t => t.EventId)
        .HasColumnAnnotation(
            IndexAnnotation.AnnotationName,
            new IndexAnnotation(
                new IndexAttribute(uniqueIndex)
                {
                    IsUnique = true,
                    Order = 1
                }
            )
        );
    
    modelBuilder.Entity<Registration>().Property(t => t.ParticipantId)
        .HasColumnAnnotation(
            IndexAnnotation.AnnotationName,
            new IndexAnnotation(
                new IndexAttribute(uniqueIndex)
                {
                    IsUnique = true,
                    Order = 2
                }
            )
        );
