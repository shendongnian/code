        private void ExecuteTransactions()
        {
            try
            {
                var restore_name = _targetDatabase.Name;
                _sw.Restart();
                Restore restore = new Restore();
                var trFile = _transactions[0];
                var backupDeviceItem = new BackupDeviceItem(trFile, DeviceType.File);
                restore.Devices.Add(backupDeviceItem);
                restore.Database = restore_name;                
                restore.ToPointInTime = _time.ToString("yyyy-MM-ddTHH:mm:ss");
                restore.ReplaceDatabase = false;
                restore.Action = RestoreActionType.Log;
                restore.PercentComplete += Restore_PercentComplete;
                restore.SqlRestoreAsync(_smoServer);
                restore.Information += Restore_Information;
                restore.Wait();
                Transaction_Complete();
            }
            catch (Exception ex)
            {
                Logger.Error("Message : " + ex.Message);
            }
        }
        private void Transaction_Complete()
        {
            _transactions.RemoveAt(0);
            if (_transactions.Count > 0)
                ExecuteTransactions();
            else
                SetDatabaseOnline();
        }
