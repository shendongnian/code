        protected static void BackupLocalDatabase(string serverInstance, string databaseName, string databaseBackupFileName)
        {
            var serverConnection = new ServerConnection(serverInstance);
            var server = new Server(serverConnection);
            try
            {
                if (server.Databases.Contains(databaseName) == false)
                {
                    throw new ArgumentException("database does not exist on server");
                }
                var timestamp = DateTime.UtcNow.ToString("u", CultureInfo.InvariantCulture);
                var description = string.Format(CultureInfo.InvariantCulture, "Backup of {0} on {1}", databaseName, timestamp);
                var backup = new Backup()
                {
                    Database = databaseName,
                    Action = BackupActionType.Database,
                    BackupSetDescription = description,
                    BackupSetName = description,
                    Incremental = false
                };
                // delete any backup we already have
                if (File.Exists(databaseBackupFileName) == true)
                {
                    File.Delete(databaseBackupFileName);
                }
                var device = new BackupDeviceItem(databaseBackupFileName, DeviceType.File);
                backup.Devices.Add(device);
                backup.PercentComplete += backup_PercentComplete;
                backup.SqlBackup(server);
                backup.PercentComplete -= backup_PercentComplete;
                serverConnection.Disconnect();
            }
            catch (SmoException ex)
            {
                Trace.TraceError("SmoException " + ex);
                throw;
            }
            catch (IOException ex)
            {
                Trace.TraceError("IOException " + ex);
                throw;
            }
        }
        static void backup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            Trace.TraceInformation("{0}", e.Message);
        }
        protected static bool CheckDatabaseExists(string serverInstance, string databaseName)
        {
            var serverConnection = new ServerConnection(serverInstance);
            var server = new Server(serverConnection);
            return server.Databases.Contains(databaseName);
        }
        protected static void RestoreLocalDatabase(string databaseBackupFileName, string destinationDirectory, string serverInstance, string databaseName)
        {
            var serverConnection = new ServerConnection(serverInstance);
            var server = new Server(serverConnection);
            Trace.TraceInformation("Restoring backup file {0} to database {1}", databaseBackupFileName, databaseName);
            try
            {
                // see if the database exists, and if it does, close it down and drop it
                if (server.Databases.Contains(databaseName))
                {
                    Trace.TraceInformation("Database exists; killing active connections (there shouldn't be any)...");
                    server.KillAllProcesses(databaseName);
                    server.Databases[databaseName].Drop();
                    Trace.TraceInformation("Active connections killed and database dropped.");
                }
                // set up the command
                var restore = new Restore()
                {
                    PercentCompleteNotification = 10,
                    Database = databaseName,
                    NoRecovery = false,
                    KeepReplication = false,
                    ReplaceDatabase = true,
                    Restart = true
                };
                restore.Devices.AddDevice(databaseBackupFileName, DeviceType.File);
                restore.PercentComplete += restore_PercentComplete;
                // relocate the source files from the backup to the local location
                var files = restore.ReadFileList(server);
                foreach (DataRow dataRow in files.Rows)
                {
                    var physicalName = dataRow["PhysicalName"].ToString();
                    var logicalName = dataRow["LogicalName"].ToString();
                    physicalName = Path.Combine(destinationDirectory, Path.GetFileName(physicalName));
                    restore.RelocateFiles.Add(new RelocateFile(logicalName, physicalName));
                    Trace.TraceInformation("Relocating physical DB file {0} to physical file {1}", dataRow["LogicalName"].ToString(), physicalName);
                }
                // do the restore
                Trace.TraceInformation("Beginning restore...");
                restore.SqlRestore(server);
                restore.Wait();
                Trace.TraceInformation("Restore complete.");
                restore.PercentComplete -= restore_PercentComplete;
                // general database housekeeping
                Trace.TraceInformation("Shrinking database (just to be sure)...");
                server.Databases[databaseName].RecoveryModel = RecoveryModel.Simple;
                server.Databases[databaseName].Shrink(1, ShrinkMethod.TruncateOnly);
                Trace.TraceInformation("Shrink complete.");
                serverConnection.Disconnect();
            }
            catch (SmoException ex)
            {
                Trace.TraceError("SmoException " + ex);
                throw;
            }
            catch (IOException ex)
            {
                Trace.TraceError("IOException " + ex);
                throw;
            }
            Trace.TraceInformation("Completed restoration of backup file {0} to database {1}", databaseBackupFileName, databaseName);
        }
        static void restore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            Trace.TraceInformation("{0}", e.Message);
        }
