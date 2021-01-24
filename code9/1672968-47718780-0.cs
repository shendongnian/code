    this.Property(x => x.Date)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                     new IndexAnnotation(new IndexAttribute("UN_Day", 0) { IsUnique = true }));
    this.Property(x => x.CalendarID)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                     new IndexAnnotation(new IndexAttribute("UN_Day", 1) { IsUnique = true }));
