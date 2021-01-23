        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Models.Game>().HasOptional(g => g.Teams).WithOptionalPrincipal(t => t.Game); // 1 -> 0..1
            modelBuilder.Entity<Models.Game>().HasOptional(g => g.Devices).WithOptionalPrincipal(d => d.Game); // 1 -> 0..1
            modelBuilder.Entity<Models.Game>().HasOptional(g => g.Scenario).WithOptionalPrincipal(s => s.Game); // 1-> 0..1
            modelBuilder.Entity<Models.Teams>().HasMany(ts => ts.TeamsList).WithRequired(t => t.Teams); // 1 -> many
            modelBuilder.Entity<Models.Team>().HasMany(t => t.Players).WithRequired(p => p.Team); // 1 -> many
            
            base.OnModelCreating(modelBuilder);
        }
