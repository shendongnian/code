    System.Data.Entity.Migrations.Infrastructure.MigrationsException: The target context 'Namespace.MyContext' is not constructible. Add a default constructor or provide an implementation of IDbContextFactory.
       at System.Data.Entity.Migrations.DbMigrator..ctor(DbMigrationsConfiguration configuration, DbContext usersContext, DatabaseExistenceState existenceState, Boolean calledByCreateDatabase)
       at System.Data.Entity.Migrations.DbMigrator..ctor(DbMigrationsConfiguration configuration)
       at System.Data.Entity.Migrations.Design.MigrationScaffolder..ctor(DbMigrationsConfiguration migrationsConfiguration)
       at System.Data.Entity.Migrations.Design.ToolingFacade.ScaffoldRunner.RunCore()
       at System.Data.Entity.Migrations.Design.ToolingFacade.BaseRunner.Run()
