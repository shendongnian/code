    public void RestoreDatabaseBackup()
    {
        ExecuteQuery("EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = 'DatabaseName");
        ExecuteQuery("USE MASTER");
        OpenFileDialog res = new OpenFileDialog();
        res.ShowDialog();
        if (res.FileName.ToString() == "")
        {
            //MessageBox.Show("Select Valid .bak File");
        }
        else
        {
            try
            {
                string s = res.FileName.ToString();
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=ServerName;Initial Catalog=yourDatabaseName;Integrated Security=True;Pooling=False");
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();
                ServerConnection ServerConnection = new ServerConnection(sqlConnection);
                Server srv = new Server(ServerConnection);
                //Declare a BackupDeviceItem by supplying the backup device file name in the constructor, and the type of device is a file.
                BackupDeviceItem bdi = default(BackupDeviceItem);
                bdi = new BackupDeviceItem(s, DeviceType.File);
                // Define a Restore object variable.
                Restore rs = new Restore();
                //Set the NoRecovery property to true, so the transactions are not recovered.
                rs.NoRecovery = true;
                rs.ReplaceDatabase = true;
                // Add the device that contains the full database backup to the Restore object.
                rs.Devices.Add(bdi);
                rs.NoRecovery = false;
                // Specify the database name.
                rs.Database = sqlConnection.Database.ToString();
                // Restore the full database backup with no recovery.
                sqlConnection.ChangeDatabase("master");
                rs.SqlRestore(srv);
                // Inform the user that the Full Database Restore is complete.
                srv = null;
                MessageBox.Show("Database Restore complete.");
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }
    }
