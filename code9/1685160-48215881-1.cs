    [System.Security.SecuritySafeCritical]  // auto-generated
    private void Dispose(bool disposing)
    {
        if (hkey != null)
        {
            if (!IsSystemKey())
            {
                try
                {
                    hkey.Dispose();
                }
                catch (IOException)
                {
                    // we don't really care if the handle is invalid at this point
                }
                finally
                {
                    hkey = null;
                }
            }
            else if (disposing && IsPerfDataKey())
            {
                // System keys should never be closed.  However, we want to call RegCloseKey
                // on HKEY_PERFORMANCE_DATA when called from PerformanceCounter.CloseSharedResources
                // (i.e. when disposing is true) so that we release the PERFLIB cache and cause it
                // to be refreshed (by re-reading the registry) when accessed subsequently. 
                // This is the only way we can see the just installed perf counter.  
                // NOTE: since HKEY_PERFORMANCE_DATA is process wide, there is inherent ---- in closing
                // the key asynchronously. While Vista is smart enough to rebuild the PERFLIB resources
                // in this situation the down level OSes are not. We have a small window of ---- between  
                // the dispose below and usage elsewhere (other threads). This is By Design. 
                // This is less of an issue when OS > NT5 (i.e Vista & higher), we can close the perfkey  
                // (to release & refresh PERFLIB resources) and the OS will rebuild PERFLIB as necessary. 
                SafeRegistryHandle.RegCloseKey(RegistryKey.HKEY_PERFORMANCE_DATA);
            }
        }
    }
