    var appPool = new DirectoryEntry(string.Format("IIS://{0}/w3svc/apppools/DefaultAppPool", Environment.MachineName));
                //Integrated mode
                appPool.InvokeSet("ManagedPipelineMode", new object[] { 0 });
                appPool.InvokeSet("MaxProcesses", new object[] { 1 });
                //Enable 32-bit Applications
                appPool.InvokeSet("Enable32BitAppOnWin64", new object[] { true });
                
                appPool.CommitChanges();
