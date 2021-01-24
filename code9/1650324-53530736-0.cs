    public class AspNetUserClaimsConfig : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.ToTable("AspNetUserClaims", "Identity");
            // Primary key
             builder.HasKey(uc => uc.Id);
        }
    }
