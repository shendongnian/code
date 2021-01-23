    protected override void OnModelCreating(DbModelBuilder mb)
    {
        mb.Entity<PatientTreatment>()
          .HasKey(x => new { x.PatientId, x.TreatmentId, x.TreatmentDate });
        mb.Entity<Patient>().HasMany(p => p.PatientTreatments)
          .WithRequired().HasForeignKey(x => x.PatientId);
        mb.Entity<Treatment>().HasMany(t => t.PatientTreatments)
          .WithRequired().HasForeignKey(x => x.TreatmentId);
        
        base.OnModelCreating(mb);
    }
