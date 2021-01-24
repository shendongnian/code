            modelBuilder.Entity<Parameter>(opt =>
            {
                opt.ToTable("Parameter");
                opt.HasKey(x => x.Id);
                opt.Property(x => x.AutoId).UseSqlServerIdentityColumn();
                opt.HasAlternateKey(x => x.AutoId);
                opt.Ignore("CreatedByUserId");
                opt.Ignore("CreatedComputerName");
                opt.Ignore("CreatedIP");
                opt.Ignore("ModifiedByUserId");
                opt.Ignore("ModifiedComputerName");
                opt.Ignore("ModifiedDate");
                opt.Ignore("ModifiedIP");
            });
