    //Local server
    var srv = new Server();  
    var db = srv.Databases["AdventureWorks2012"];    
    var bk = new Backup
             {
                 Action = BackupActionType.Database,
                 BackupSetDescription = "Full backup of Adventureworks2012",
                 BackupSetName = "AdventureWorks2012 Backup",
                 Database = "AdventureWorks2012",
                 Checksum = true
             };
  
    var bdi = new BackupDeviceItem(fullDestinationPath,DeviceType.File);  
    bk.Devices.Add(bdi);  
    bk.SqlBackup(srv);  
