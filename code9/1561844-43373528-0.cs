    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    
    namespace BackupApplication
    {
        class DatabaseBackup
        {    
            public void DoDataBaseBackup()
            {    
                string connectionString = ConfigurationManager.ConnectionStrings["Test"].ToString();
                SqlConnection connecton = new SqlConnection(connectionString);
                ServerConnection serverConnection = new ServerConnection(connecton);
                Server myServer = new Server(serverConnection);
        
                //Using windows authentication                
                myServer.ConnectionContext.Connect();
        
                Database myDatabase = myServer.Databases[ConfigurationManager.AppSettings["DatabaseNameToBackup"]];
    
                //Backup operation
                Backup bkpDBFull = new Backup();
                /* Specify whether you want to back up database or files or log */
                bkpDBFull.Action = BackupActionType.Database;
    
                /* Specify the name of the database to back up */
                bkpDBFull.Database = myDatabase.Name;
        
                /* You can take backup on several media type (disk or tape), here I am
                 * using File type and storing backup on the file system */
                string destinationFolderForDatabase = ConfigurationManager.AppSettings["DestinationFolderForDatabase"];
                bkpDBFull.Devices.AddDevice(destinationFolderForDatabase, DeviceType.File);
                bkpDBFull.BackupSetName = "Test database Backup";
                bkpDBFull.BackupSetDescription = "test database - Full Backup";
    
    
                /* You can specify the expiration date for your backup data
                 * after that date backup data would not be relevant */
                bkpDBFull.ExpirationDate = DateTime.Today.AddDays(10);
    
                /* You can specify Initialize = false (default) to create a new 
                 * backup set which will be appended as last backup set on the media. You
                 * can specify Initialize = true to make the backup as first set on the
                 * medium and to overwrite any other existing backup sets if the all the
                 * backup sets have expired and specified backup set name matches with
                 * the name on the medium */
                bkpDBFull.Initialize = false;
    
                /* You can specify Incremental = false (default) to perform full backup or Incremental = true to perform differential backup since most recent full backup */
                bkpDBFull.Incremental = false;
    
                /* Wiring up events for progress monitoring */
                bkpDBFull.PercentComplete += CompletionStatusInPercent;
                bkpDBFull.Complete += Backup_Completed;
    
                /* SqlBackup method starts to take back up
                 * You can also use SqlBackupAsync method to perform the backup 
                 * operation asynchronously */
                bkpDBFull.SqlBackup(myServer);
    
        Restore restore = new Restore();
        restore.Devices.AddDevice(@"C:\Test.bak", DeviceType.File);
        restore.Database = "Test2012";
        Console.WriteLine(restore.SqlVerify(myServer).ToString());
                if (myServer.ConnectionContext.IsOpen)
                {
                    myServer.ConnectionContext.Disconnect();
                }
            }
    
            private void Backup_Completed(object sender, ServerMessageEventArgs e)
            {
                Console.WriteLine("TestDatabase Backup Completed.");
                Console.WriteLine(e.Error.Message);            
            }
    
            private void CompletionStatusInPercent(object sender, PercentCompleteEventArgs e)
            {
                Console.Clear();
                Console.WriteLine("Percent completed: {0}%.", e.Percent);
            }
        }
    }
