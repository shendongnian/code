    TimeSpan immediately = TimeSpan.Zero;
    
    var userRoutine = new System.Threading.Timer(
        o => SyncUsers(o), null, immediately, userMatchFrequency);
    var materialRoutine = new Timer(
        o => SyncMaterials(o), null, immediately, materialSyncFrequency);
    var activityRoutine = new Timer(
        o => SyncActivities(o), null, immediately, activitySyncFrequency);
    var customerRoutine = new Timer(
        o => SyncCustomers(o), null, immediately, customerSyncFrequency);
    while (true)
    {
        Console.ReadKey(false);
    }
    GC.KeepAlive(userRoutine);
    GC.KeepAlive(materialRoutine);
    GC.KeepAlive(activityRoutine);
    GC.KeepAlive(customerRoutine);
