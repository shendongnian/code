    public class SampleDbContext : DbContext
            {
                public SampleDbContext()
                    : base("name=SampleDBConnection")
                {
                    this.Configuration.LazyLoadingEnabled = true;
                    this.Configuration.ProxyCreationEnabled = true;
                }
                public DbSet<Customer> Customers { get; set; }
                public DbSet<User> Users { get; set; }
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    modelBuilder.Conventions.Add(new FunctionsConvention<SampleDbContext>("dbo"));
                 
                }
                [DbFunction("SampleDbContext", "CustomersByZipCode")]
                public IQueryable<Customer> CustomersByZipCode(string zipCode)
                {
                    var zipCodeParameter = zipCode != null ?
                        new ObjectParameter("ZipCode", zipCode) :
                        new ObjectParameter("ZipCode", typeof(string));
                    return ((IObjectContextAdapter)this).ObjectContext
                        .CreateQuery<Customer>(
                            string.Format("[{0}].{1}", GetType().Name,
                                "[CustomersByZipCode](@ZipCode)"), zipCodeParameter);
                }
                [DbFunction("SampleDbContext", "GetUser")]
                public virtual IQueryable<User> GetUser(int? id)
                {
                    var idParameter = id.HasValue ?
                    new ObjectParameter("ID", id) :
                    new ObjectParameter("ID", typeof(int));
                    return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<User>(
                            string.Format("[{0}].{1}", GetType().Name,
                                "[GetUser](@ID)"), idParameter);
                }
            }
