`
string databasePath = AppDomain.CurrentDomain.BaseDirectory + "Scheduler.db";
        if (MessageBox.Show("Do you want to delete database: [Scheduler.db]?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
        {
            if (File.Exists(databasePath))
            { 
                SQLiteConnection connectionSqlLIte = new SQLiteConnection(@"Data Source=Scheduler.db;Version=3;"); 
                connectionSqlLIte. Close();
                //Force a garbage collection here
                GC.Collect();
                GC.WaitForPendingFinalizers();
      
                //Now you should be able to delete the file now
                File.Delete(databasePath);
                MessageBox.Show("Database deleted: [Scheduler] ");
                Application.Current.Shutdown();  
            }
            else
            {
                MessageBox.Show("There is no database: [Scheduler]!");
            }
        }
