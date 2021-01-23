    modelBuilder.Entity<A>().HasRequired(e => e.B).WithMany().HasForeignKey(e => e.B_Id);
    modelBuilder.Entity<A>().HasRequired(e => e.C).WithMany().HasForeignKey(e => e.C_Id);
    
    modelBuilder.Entity<A>().Property(e => e.B_Id).HasColumnAnnotation("Index", 
    	new IndexAnnotation(new IndexAttribute("IX_BC", 1) { IsUnique = true }));
    modelBuilder.Entity<A>().Property(e => e.C_Id).HasColumnAnnotation("Index", 
    	new IndexAnnotation(new IndexAttribute("IX_BC", 2) { IsUnique = true }));
