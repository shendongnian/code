    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace SqlDependencyExample
    {
        class Program
        {
    
            static string connectionString = @"Data Source=.;Initial Catalog=YourDatabase;Application Name=SqlDependencyExample;Integrated Security=SSPI";
    
            static void Main(string[] args)
            {
    
                SqlDependency.Start(connectionString);
    
                getDataWithSqlDependency();
                Console.WriteLine("Waiting for data changes");
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
                SqlDependency.Stop(connectionString);
    
            }
    
            static DataTable getDataWithSqlDependency()
            {
    
                using (var connection = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("SELECT Col1, Col2, Col3 FROM dbo.MyTable;", connection))
                {
    
                    var dt = new DataTable();
    
                    // Create dependency for this command and add event handler
                    var dependency = new SqlDependency(cmd);
                    dependency.OnChange += new OnChangeEventHandler(onDependencyChange);
    
                    // execute command to get data
                    connection.Open();
                    dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
    
                    return dt;
    
                }
    
            }
    
            // Handler method
            static void onDependencyChange(object sender,
               SqlNotificationEventArgs e)
            {
    
                Console.WriteLine($"OnChange Event fired. SqlNotificationEventArgs: Info={e.Info}, Source={e.Source}, Type={e.Type}.");
    
                if ((e.Info != SqlNotificationInfo.Invalid)
                    && (e.Type != SqlNotificationType.Subscribe))
                {
                    //resubscribe
                    var dt = getDataWithSqlDependency();
    
                    Console.WriteLine($"Data changed. {dt.Rows.Count} rows returned.");
                }
                else
                {
                    Console.WriteLine("SqlDependency not restarted");
                }
    
            }
    
    
        }
    }
