    [FunctionName("Function1")]
    public static void Run(
        [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, 
        [Blob("mycontainer/myblob.txt", FileAccess.Write)] out string outputBlob,
        TraceWriter log)
    {
        var str = ConfigurationManager.ConnectionStrings["sqldb_connection"].ConnectionString;
        using (var conn = new SqlConnection(str))
        {
            conn.Open();
            var text = "SELECT count(*) FROM MyData";
            using (var cmd = new SqlCommand(text, conn))
            {
                // Execute the command and log the # rows affected.
                var rows = cmd.ExecuteNonQuery();
                outputBlob = $"{rows} rows found";
            }
        }
    }
