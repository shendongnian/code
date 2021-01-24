        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser >().Ignore(u => u.Author);
            modelBuilder.Entity<Author>().Ignore(a => a.ApplicationUser);
            
            //rest of the code 
       }
