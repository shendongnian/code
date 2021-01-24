[Table("dbname.scheme.Stock", Schema = "dbo")]
will get rendered in the sql as 
[dbo].[dbname.scheme.Stock]
when what you actually want in the SQL is
[dbname].[dbo].[Stock]
Even if you try and mess around with it wont work. I tried various combinations 
[Table("Stock", Schema = "dbname.dbo")] // SQL => [dbname.dbo].[Stock]
[Table("Stock", Schema = "[dbname].[dbo]")] // SQL => [[dbname]].[dbo]]].[Stock]
[Table("Stock", Schema = "dbname].[dbo")] // SQL => [dbname]].[dbo].[Stock]
[Table("Stock", Schema = "dbname.[dbo")] // SQL => [dbname.[dbo].[Stock]
...etc.  The basic problem is that you need to separate the dbname with brackets that get escaped when it's parsed. 
This actually appears to be a known issue, with a solution in the pipeline (although it hasn't been prioritised yet): 
https://github.com/aspnet/EntityFrameworkCore/issues/4019
I did however find an interim solution to this problem, and it's based on two sources:
https://stackoverflow.com/a/26922902/861352 (EF6 solution)
https://weblogs.asp.net/ricardoperes/interception-in-entity-framework-core
And here it is:
***************************************************
How To Do (Same Server) Cross DB Joins With One EF Core DbContext
***************************************************
using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DiagnosticAdapter;
namespace Example
{
    public class CommandInterceptor
    {
        [DiagnosticName("Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting")]
        public void OnCommandExecuting(DbCommand command, DbCommandMethod executeMethod, Guid commandId, Guid connectionId, bool async, DateTimeOffset startTime)
        {
            var secondaryDatabaseName = "MyOtherDatabase";
            var schemaName = "dbo";
            var tableName = "Stock";
            command.CommandText = command.CommandText.Replace($" [{tableName}]", $" [{schemaName}].[{tableName}]")
                                                     .Replace($" [{schemaName}].[{tableName}]", $" [{secondaryDatabaseName}].[{schemaName}].[{tableName}]");
        }
    }
}
Replace 'MyOtherDatabase', 'dbo' and 'Stock' with your Database name, table schema and table name, maybe from a config etc. 
Then attach that interceptor to your context.
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
 
var context = new MultipleDatabasesExampleDbContext(optionsBuilder.Options);
// Add interceptor to switch between databases
var listener = context.GetService<DiagnosticSource>();
(listener as DiagnosticListener).SubscribeWithAdapter(new CommandInterceptor());
In my case I put the above in MultipleDatabasesExampleDbContextFactory method.
Now you can just use the context as if you were referencing one database.
