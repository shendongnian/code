    string dbSource = "server=192.168.1.100;user=root;pwd=1234;database=db1;";
    string dbTarget = "server=192.168.1.200;user=root;pwd=1234;database=db1;";
    
    string sqlDump = "";
    
    // Backup from source database
    using (MySqlConnection conn = new MySqlConnection(dbSource))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                conn.Open();
                cmd.Connection = conn;
    
                sqlDump = mb.ExportToString();
    
                conn.Close();
            }
        }
    }
    
    // Restore to target database
    using (MySqlConnection conn = new MySqlConnection(dbTarget))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                conn.Open();
                cmd.Connection = conn;
    
                mb.ImportFromString(sqlDump);
    
                conn.Close();
            }
        }
    }
