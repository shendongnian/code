    public class ContactContext : DbContext
    {
        private ContactContext(DbConnection connection, DbCompiledModel model)
            : base(connection, model, contextOwnsConnection: false)
        { }
    
        public DbSet<Person> People { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
    
        private static ConcurrentDictionary<Tuple<string, string>, DbCompiledModel> modelCache
            = new ConcurrentDictionary<Tuple<string, string>, DbCompiledModel>();
    
        /// <summary>
        /// Creates a context that will access the specified tenant
        /// </summary>
        public static ContactContext Create(string tenantSchema, DbConnection connection)
        {
            var compiledModel = modelCache.GetOrAdd(
                Tuple.Create(connection.ConnectionString, tenantSchema),
                t =>
                {
                    var builder = new DbModelBuilder();
                    builder.Conventions.Remove<IncludeMetadataConvention>();
                    builder.Entity<Person>().ToTable("Person", tenantSchema);
                    builder.Entity<ContactInfo>().ToTable("ContactInfo", tenantSchema);
    
                    var model = builder.Build(connection);
                    return model.Compile();
                });
    
            return new ContactContext(connection, compiledModel);
        }
    
        /// <summary>
        /// Creates the database and/or tables for a new tenant
        /// </summary>
        public static void ProvisionTenant(string tenantSchema, DbConnection connection)
        {
            using (var ctx = Create(tenantSchema, connection))
            {
                if (!ctx.Database.Exists())
                {
                    ctx.Database.Create();
                }
                else
                {
                    var createScript = ((IObjectContextAdapter)ctx).ObjectContext.CreateDatabaseScript();
                    ctx.Database.ExecuteSqlCommand(createScript);
                }
            }
        }
    }
