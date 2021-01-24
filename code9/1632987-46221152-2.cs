    class TypeEntityConvention : Convention
    {
        public TypeEntityConvention()
        {
            this.Types<TypeEntity>().Configure(c =>
            {
                c.HasKey(p => p.Key);
                c.Property(p => p.Key).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                c.ToTable(c.ClrType.Name);
            });
        }
    }
