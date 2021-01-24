    // Microsoft.SqlServer.Management.Trace.TraceServer
    public void InitializeAsReader(ConnectionInfoBase serverConnInfo, string profileFileName)
    {
    	try
    	{
    		this.rowsetCtrl = (TraceUtils.CreateInstance("\\Binn\\pfclnt.dll", "Microsoft.SqlServer.Management.Trace.CTraceObjectsRowsetController") as ITraceObjectsRowsetController);
    		this.rowsetCtrl.Initialize(serverConnInfo, profileFileName);
    		this.rowsetCtrl.InitSource(false);
    		this.traceController = this.rowsetCtrl;
    	}
    	catch (Exception ex)
    	{
    		TraceUtils.FilterException(ex);
    		throw new SqlTraceException(typeof(StringConnectionInfo), "CannotInitializeAsReader", ex);
    	}
    }
