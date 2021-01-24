    static void Main(string[] args) {
        TimeSpan immediately = TimeSpan.Zero;
        var userMatchFrequency = TimeSpan.FromSeconds(1);
        var materialSyncFrequency = TimeSpan.FromSeconds(2);
        var activitySyncFrequency = TimeSpan.FromSeconds(3);
        var customerSyncFrequency = TimeSpan.FromSeconds(4);
        using (new Timer(o => SyncUsers(o), null, immediately, userMatchFrequency))
        using (new Timer(o => SyncMaterials(o), null, immediately, materialSyncFrequency))
        using (new Timer(o => SyncActivities(o), null, immediately, activitySyncFrequency))
        using (new Timer(o => SyncCustomers(o), null, immediately, customerSyncFrequency))
             Console.ReadKey(false);                    
    }
