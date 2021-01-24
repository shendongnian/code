    public static class EntityBaseConfiguration
    {
    	public static void ConfigureBase<TEntity>(this EntityTypeBuilder<TEntity> builder)
    		where TEntity : EntityBase
    	{
    		builder.HasIndex(e => e.TenantId);
    		builder.Property(e => e.CreatedOn)
    			  .ValueGeneratedOnAdd()
    			  .HasDefaultValueSql("GETDATE()");
    
    	}
    }
