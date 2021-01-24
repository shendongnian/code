    public static class CustomerMap
    { 
        public static EntityTypeBuilder<Customer> Map(this EntityTypeBuilder<Customer> cfg)
        {
            cfg.ToTable("CUSTOMER");
            cfg.HasKey(x => x.Id);
            cfg.Property(x => x.CreationDate).IsRequired();
            cfg.Property(x => x.IsActive).IsRequired();
            cfg.Property(x => x.BirthDay).IsRequired();
            cfg.OwnsOne(x => x.Email);
            cfg.OwnsOne(x => x.Name);
            cfg.HasMany(x => x.CreditDebitCards).WithOne(y => y.Customer);
            //cfg.HasOne(x => x.Seller).WithOne(y => y.Customer).IsRequired(false);
            return cfg;
        }
    }
