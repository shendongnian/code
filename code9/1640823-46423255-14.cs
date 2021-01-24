    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\temp\BigSpreadsheet.xlsx;Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
    DataTable dt = new DataTable();
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        using (OleDbCommand cmd = new OleDbCommand())
        {
            cmd.CommandText = "select * from [Sheet1$]";
            cmd.Connection = conn;
            using (OleDbDataAdapter da = new OleDbDataAdapter())
            {
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
        }
    }
    
    stopWatch.Stop();
    
    Console.WriteLine("Using OleDb: {0} seconds", stopWatch.ElapsedMilliseconds / 1000);
    
    Console.WriteLine("Press any key to exit");
    
    Console.ReadLine();
