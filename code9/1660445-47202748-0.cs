    OleDbConnection conn = new OleDbConnection();
    conn.ConnectionString = String.Format("{0}{1}",
        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", @"c:\Access\MyDb.accdb");
    conn.Open();
    bool valid;
    using (OleDbCommand cmd = new OleDbCommand("select [Bad Field] from [Table]", conn))
    {
        try
        {
            OleDbDataReader reader = cmd.ExecuteReader();
            valid = true;
            reader.Close();   // Did not ever call reader.Read()
        }
        catch (Exception ex)
        {
            valid = false;
        }
    }
