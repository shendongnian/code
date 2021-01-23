public class ApplicationCompanyConfiguration : IEntityTypeConfiguration<Company>
{
	public void Configure(EntityTypeBuilder<Company> builder)
	{
		builder.ToTable("Company");	
		builder.HasIndex(p => p.Name).IsUnique();
	}
}
