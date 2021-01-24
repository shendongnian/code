[Table("dbname.scheme.Stock", Schema = "dbo")]
will get rendered in the sql as 
[dbo].[dbname.scheme.Stock]
when what you actually want in the SQL is
[dbname].[dbo].[Stock]
Even if you try and mess around with it wont work. I tried various combinations 
[Table("Stock", Schema = "dbname.dbo")] // SQL => [dbname.scheme].[Stock]
[Table("Stock", Schema = "[dbname].[dbo]")] // SQL => [[dbname]].[dbo]]].[Stock]
[Table("Stock", Schema = "dbname].[dbo")] // SQL => [dbname]].[dbo].[Stock]
[Table("Stock", Schema = "dbname.[dbo")] // SQL => [dbname.[dbo].[Stock]
...etc.  The basic problem is that you need to separate the dbname with brackets that get escaped when it's parsed. If anyone does find a way to do it via that mechanism please let me know....
I did however find a solution for this problem, and it's based on two sources:
https://stackoverflow.com/a/26922902/861352 (EF6 solution)
https://weblogs.asp.net/ricardoperes/interception-in-entity-framework-core
And here it is:
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
