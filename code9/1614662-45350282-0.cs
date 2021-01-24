    modelBuilder.Entity<Project>(entity =>
    {
    // Fluent API for column properties
    ...
    entity.HasOne(d => d.PmEmployee)
        .WithMany(p => p.PmProjects)
        .HasForeignKey(d => d.PmEmployeeId)
        .OnDelete(DeleteBehavior.SetNull)
        .HasConstraintName("FK_Project_Employee_PM");
    entity.HasOne(d => d.CadEmployee)
        .WithMany(p => p.CadProjects)
        .HasForeignKey(d => d.CadEmployeeId)
        .OnDelete(DeleteBehavior.SetNull)
        .HasConstraintName("FK_Project_Employee_CAD");
     entity.HasOne(d => d.SalesRepEmployee)
        .WithMany(p => p.SalesProjects)
        .HasForeignKey(d => d.SalesRepEmployeeId)
        .OnDelete(DeleteBehavior.SetNull)
        .HasConstraintName("FK_Project_Employee_SALES");
     });
