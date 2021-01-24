    public static class SellerMap 
        {
            public static EntityTypeBuilder<Seller> Map(this EntityTypeBuilder<Seller> cfg)
            {
                cfg.ToTable("SELLER");
                cfg.HasKey(x => x.Id);
                cfg.Property(x => x.CreationDate).IsRequired();
                cfg.Property(x => x.IsActive).IsRequired();
                cfg.HasOne(x => x.Customer).WithOne(y => y.Seller).HasForeignKey<Customer>(z => z.SellerId);
                cfg.Property(x => x.CardIdPath).IsRequired();
                cfg.Property(x => x.IdentityNumber);
                cfg.Property(x => x.SchoolName);
    
                return cfg;
            }
        }
