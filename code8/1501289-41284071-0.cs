    internal sealed class Configuration : DbMigrationsConfiguration<CCDatabase.CCDbContext>
	public Configuration()
	{
		AutomaticMigrationsEnabled = false;
		MigrationsDirectory = @"Migrations";
		SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
		SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
	}
