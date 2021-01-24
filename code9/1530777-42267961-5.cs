    static void Main(string[] args) {
        TimeSpan immediately = TimeSpan.Zero;
        var userMatchFrequency = TimeSpan.FromSeconds(1);
        var materialSyncFrequency = TimeSpan.FromSeconds(2);
        var activitySyncFrequency = TimeSpan.FromSeconds(3);
        var customerSyncFrequency = TimeSpan.FromSeconds(4);
        var userRoutine = new System.Threading.Timer(
            o => SyncUsers(o), null, immediately, userMatchFrequency);
        var materialRoutine = new Timer(
            o => SyncMaterials(o), null, immediately, materialSyncFrequency);
        var activityRoutine = new Timer(
            o => SyncActivities(o), null, immediately, activitySyncFrequency);
        var customerRoutine = new Timer(
            o => SyncCustomers(o), null, immediately, customerSyncFrequency);
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        Console.ReadKey(false);
    }
    static void SyncUsers(object o) {
        Console.WriteLine("Sync users");
    }
    static void SyncMaterials(object o)
    {
        Console.WriteLine("Sync meterials");
    }
    static void SyncActivities(object o)
    {
        Console.WriteLine("Sync activities");
    }
    static void SyncCustomers(object o)
    {
        Console.WriteLine("Sync customers");
    }
