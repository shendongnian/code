    private void DisplayAllRecords()
    {
        IsBusy = true;
        Task.Factory.StartNew(() =>
        {
            //this code is executed on a background thread
            String sqlConnect = SqlConnectionString;
            DbConnection connection = EFConnectionFactory.MakeConnection(sqlConnect);
            List<DataRecord> Batches = new List<DataRecord>();
            using (var db = new efContext(connection))
            {
                DbSet<DataRecord> Result = db.DataRecords;
                foreach (DataRecord dr in Result)
                {
                    RecordsList.Add(dr);
                }
            }
        }).ContinueWith(task =>
        {
            //this code is executed back on the UI thread
            ListCollectionView lcv = new ListCollectionView(RecordsList);
            DataRecordsGridContent = lcv;
            IsBusy = false;
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
