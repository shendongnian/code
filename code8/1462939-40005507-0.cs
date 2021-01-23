		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, byte[]>> propertyExpression,
			Func<BinaryPropertyConfiguration, BinaryPropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
