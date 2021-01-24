    public static class ConfigurationExtensions
    {
    	public static void HasPrimaryKey<TEntityType>(this EntityTypeConfiguration<TEntityType> configuration)
    		where TEntityType : class, IEntity
    	{
    		var parameter = Expression.Parameter(typeof(TEntityType), "m");
    		var keyProperty = Expression.Lambda<Func<TEntityType, int>>(Expression.Property(parameter, nameof(IEntity.Id)), parameter);
    		configuration
    			.HasKey(keyProperty)
    			.Property(keyProperty)
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    	}
    }
