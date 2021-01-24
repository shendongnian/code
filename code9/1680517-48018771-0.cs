    static void Main(string[] args)
            {
                using (HYBRIDM5_MeyerEntities context=new HYBRIDM5_MeyerEntities())
                {
                    ExecuteDeleteSQL(context, "Sicil");
                }
            }
    
            public static void ExecuteDeleteSQL(HYBRIDM5_MeyerEntities context, string tableName)
            {
                context.Database.ExecuteSqlCommand($"Delete from dbo.{tableName}");
            }
