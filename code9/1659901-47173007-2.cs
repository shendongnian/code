    // Add at the top of the file
    using System.Reflection;
    // anywhere
    private static bool hasRemovedFoldersFromMonitoring = false;
    
    private void StopMonitoring(FileChangesMonitor fcm, string monitorName)
    {
     var f = typeof(FileChangesMonitor).GetField(monitorName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
    
            var monitor = f.GetValue(fcm);
            var m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance |BindingFlags.NonPublic); 
            m.Invoke(monitor, new object[] { }); 
    }
    protected void Application_AcquireRequestState(object sender, EventArgs e)
    {
        if(!hasRemovedFoldersFromMonitoring){
            var fcmPi = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    
            var fcm = (FileChangesMonitor)fcmPi .GetValue(null, null);
            this.StopMonitoring(fcm, "_dirMonSubdirs");
            this.StopMonitoring(fcm, "_dirMonAppPathInternal");
            
            hasRemovedFoldersFromMonitoring = true;
        }
    }
