    private static bool hasRemovedFoldersFromMonitoring = false;
    
    protected void Application_AcquireRequestState(object sender, EventArgs e)
    {
        if(!hasRemovedFoldersFromMonitoring){
            System.Reflection.PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
    
            object o = p.GetValue(null, null);
            System.Reflection.FieldInfo f = o.GetType().GetField("_dirMonSubdirs", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.IgnoreCase);
    
            object monitor = f.GetValue(o);
            System.Reflection.MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic); m.Invoke(monitor, new object[] { }); 
            hasRemovedFoldersFromMonitoring = true;
        }
    }
