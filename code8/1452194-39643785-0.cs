    public class YourDbContext: DbContext
    {
         public YourDbContext():base("ConnectionString")
         {              
                if (Database.Exists())
                {
                    Database.ExecuteSqlCommand("if object_id('CT_DefaultGuid') is null alter table YourTable add constraint CT_DefaultGuid default newid() for YourColumn");
                }
         }
    }
