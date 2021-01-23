    public class MyModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
            => context is MyContext myContext ?
            (context.GetType(), myContext.ModelCacheKey) :
            (object)context.GetType();
    }
    public partial class MyContext : DbContext
    {
         public string Company { get; }
         public string ModelCacheKey { get; }
         public MyContext(string connectionString, string company) : base(connectionString) 
         { 
             Company = company;
             ModelCacheKey = company; //the identifier for the model this instance will use
         }
    
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             //This will create one model cache per key
             optionsBuilder.ReplaceService<IModelCacheKeyFactory, MyModelCacheKeyFactory();
         }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             SetCustomConfigurations(modelBuilder);
             modelBuilder.Entity<Order>(entity => 
             { 
                 //regular entity mapping 
             });
         }
         public void SetCustomConfigurations(ModelBuilder modelBuilder)
         {
             //Here you will set the schema. 
             //In my example I am setting custom table name Order_CompanyX
    
             var entityType = typeof(Order);
             var tableName = entityType.Name + "_" + this.Company;
             var mutableEntityType = modelBuilder.Model.GetOrAddEntityType(entityType);
             mutableEntityType.RemoveAnnotation("Relational:TableName");
             mutableEntityType.AddAnnotation("Relational:TableName", suffixTableName);
         }
    }
