    public JwtContext() : base("name=Jwt")
        {
            // to alter the database.This tell the database to close all connection and if a transaction is open to rollback this one.
             Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", Database.Connection.Database));
            Database.Delete();
            Database.SetInitializer(new JwtDbInitializer<JwtContext>());
        }
