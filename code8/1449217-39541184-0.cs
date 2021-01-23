       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
           modelBuilder.Entity<ClassA>()
               .HasOptional(c => c.ClassC)
               .WithMany()
               .HasForeignKey(c => c.ClassCId)
               .WillCascadeOnDelete(false);
           base.OnModelCreating(modelBuilder);
        }
