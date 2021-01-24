    <%@ import namespace="System.Reflection"%>
    private static bool hasRemovedFoldersFromMonitoring = false;
    protected void Application_AcquireRequestState(object sender, EventArgs e)
    {
        if (!hasRemovedFoldersFromMonitoring)
        {           
            PropertyInfo fcmPi = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            object o = fcmPi.GetValue(null, null);
            FieldInfo fi_dirMonSubdirs = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
            object monitor_dirMonSubdirs = fi_dirMonSubdirs.GetValue(o);
            MethodInfo m_dirMonSubdirs = monitor_dirMonSubdirs.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
            m_dirMonSubdirs.Invoke(monitor_dirMonSubdirs, new object[] { });
            FieldInfo fi_dirMonAppPathInternal = o.GetType().GetField("_dirMonAppPathInternal", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
            object monitor_dirMonAppPathInternal = fi_dirMonAppPathInternal.GetValue(o);
            if (monitor_dirMonAppPathInternal != null)
            {
                MethodInfo m_dirMonAppPathInternal = monitor_dirMonAppPathInternal.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
                m_dirMonAppPathInternal.Invoke(monitor_dirMonAppPathInternal, new object[] { });
            }
            hasRemovedFoldersFromMonitoring = true;
        }
    }
