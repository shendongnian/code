        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Primary keys
            modelBuilder.Entity<Atendimento>().HasKey(a => a.Id);
            modelBuilder.Entity<CaixaTransacao>().HasKey(c => c.Id);
            // Foreign Key
            modelBuilder.Entity<Atendimento>()
                        .HasOptional(a => a.CaixaTransacao)
                        .WithRequired(c => c.Atendimento)
                        .Map(c => c.MapKey("AtendimentoId")); // here we show the column for FK
        }
