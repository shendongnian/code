    protected override void OnModelCreating(ModelBuilder modelBuilder){
        foreach (Type type in GetEntityTypes(typeof(BaseEntity))){
            var method = SetGlobalQueryMethod.MakeGenericMethod(type);
            method.Invoke(this, new object[] { modelBuilder });
        }
    }
	
	static readonly MethodInfo SetGlobalQueryMethod = typeof(/*your*/Context)
		.GetMethods(BindingFlags.Public | BindingFlags.Instance)
		.Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");
    public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity{
        builder.Entity<T>().Property(o => o.CreatedDateTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
        // Additional Statements
    }
