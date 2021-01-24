	Backup bkpDBFull = new Backup();
	/* Specify whether you want to back up database or files or log */
	bkpDBFull.Action = BackupActionType.Database;
	/* Specify the name of the database to back up */
	bkpDBFull.Database = myDatabase.Name;
	/* You can take backup on several media type (disk or tape), here I am
	 * using File type and storing backup on the file system */
	bkpDBFull.Devices.AddDevice(@"D:\AdventureWorksFull.bak", DeviceType.File);
	bkpDBFull.BackupSetName = "Adventureworks database Backup";
	bkpDBFull.BackupSetDescription = "Adventureworks database - Full Backup";
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
	 
	/* Wiring up events for progress monitoring */
	bkpDBFull.PercentComplete += CompletionStatusInPercent;
	bkpDBFull.Complete += Backup_Completed;
	 
	/* SqlBackup method starts to take back up
	 * You can also use SqlBackupAsync method to perform the backup 
	 * operation asynchronously */
	bkpDBFull.SqlBackup(myServer);
	private static void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
	{
		Console.Clear();
		Console.WriteLine("Percent completed: {0}%.", args.Percent);
	}
	private static void Backup_Completed(object sender, ServerMessageEventArgs args)
	{
		Console.WriteLine("Hurray...Backup completed." );
		Console.WriteLine(args.Error.Message);
	}
	private static void Restore_Completed(object sender, ServerMessageEventArgs args)
	{
		Console.WriteLine("Hurray...Restore completed.");
		Console.WriteLine(args.Error.Message);
	}
