    internal class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<Company>
        {
            public void Configure(EntityTypeBuilder<Company> builder)
            {
                #region Address value object workaround
                builder.Property(typeof(string), "Address_Street").HasColumnName("Address_Street");
                builder.Property(typeof(int), "Address_Number").HasColumnName("Address_Number");
                #endregion
            }
        }
