C#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	base.OnModelCreating(modelBuilder);
	modelBuilder.Entity<Entity1>().Property(e => e.Id).ValueGeneratedNever();
	modelBuilder.Entity<Entity2>().Property(e => e.Id).ValueGeneratedNever();
	...
}
But that wasn't enough and I had to disable the SQL Server `IDENTITY_INSERT`. This worked when inserting data in a single table. But when you have entities related to one another and you want to insert a graph of objects this fails on `DbContext.SaveChanges()`. The reason is that as per [SQL Server documentation][2] you can have `IDENTITY_INSERT ON` just for one table at a time during a session. My colleague suggested to use a `DbCommandInterceptor` which is similar to the [other answer to this question][3]. I made it work for `INSERT INTO` only but the concept could be expanded further. Currently it intercepts and modifies multiple `INSERT INTO` statements within a single `DbCommand.CommandText`. The code could be optimized to use [Span<T>.Slice][4] in order to avoid too much memory due to string manipulation but since I couldn't find a `Split` method I didn't invest time into this. I am using this `DbCommandInterceptor` for integration testing anyway. Feel free to use it if you find it helpful.
C#
/// <summary>
/// When enabled intercepts each INSERT INTO statement and detects which table is being inserted into, if any.
/// Then adds the "SET IDENTITY_INSERT table ON;" (and same for OFF) statement before (and after) the actual insertion.
/// </summary>
public class IdentityInsertInterceptor : DbCommandInterceptor
{
	public bool IsEnabled { get; set; }
	public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
	{
		if (IsEnabled)
		{
			ModifyAllStatements(command);
		}
		return base.ReaderExecuting(command, eventData, result);
	}
	private static void ModifyAllStatements(DbCommand command)
	{
		string[] statements = command.CommandText.Split(';', StringSplitOptions.RemoveEmptyEntries);
		var commandTextBuilder = new StringBuilder(capacity: command.CommandText.Length * 2);
		foreach (string statement in statements)
		{
			string modified = ModifyStatement(statement);
			commandTextBuilder.Append(modified);
		}
		command.CommandText = commandTextBuilder.ToString();
	}
	private static string ModifyStatement(string statement)
	{
		const string insertIntoText = "INSERT INTO [";
		int insertIntoIndex = statement.IndexOf(insertIntoText, StringComparison.InvariantCultureIgnoreCase);
		if (insertIntoIndex < 0)
			return $"{statement};";
		int closingBracketIndex = statement.IndexOf("]", startIndex: insertIntoIndex, StringComparison.InvariantCultureIgnoreCase);
		string tableName = statement.Substring(
			startIndex: insertIntoIndex + insertIntoText.Length,
			length: closingBracketIndex - insertIntoIndex - insertIntoText.Length);
		// we should probably check whether the table is expected - list with allowed/disallowed tables
		string modified = $"SET IDENTITY_INSERT [{tableName}] ON; {statement}; SET IDENTITY_INSERT [{tableName}] OFF;";
		return modified;
	}
}
  [1]: http://www.natpryce.com/articles/000714.html
  [2]: https://docs.microsoft.com/en-us/sql/t-sql/statements/set-identity-insert-transact-sql?view=sql-server-2017#remarks
  [3]: https://stackoverflow.com/a/42040415/608971
  [4]: https://docs.microsoft.com/en-us/dotnet/api/system.span-1.slice?view=netcore-3.1
