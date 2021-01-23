      public class TableNameConfiguration : IEntityTypeConfiguration<TableName>
        {
            public void Configure(EntityTypeBuilder<TableName> builder)
            {
               //.HasMaxLength takes precedence over operation MaxLengthAttribute(500)
               builder.Property(x => x.Title ).IsRequired().HasMaxLength(20);
            }
        }
