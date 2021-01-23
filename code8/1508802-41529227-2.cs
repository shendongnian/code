    public void RunSync()
    {
    	SystemManager.RunWithElevatedPrivilegeDelegate worker = new SystemManager.RunWithElevatedPrivilegeDelegate(args => {
    		
    		dataSource.GetResponse();
    		List<SyncContent> dataToSync = dataSource.GetDataForSync();
    		var destinationSync = new SFDynamicModuleSync(dataToSync);
    
    		destinationSync.CacheModuleData();
    
    		// complete sync operations for each content type
    		for (int i = 0; i < dataToSync.Count; i++)
    		{
    			destinationSync.DeleteOldItems(i);
    			destinationSync.AddItems(i);
    			destinationSync.UpdateItems(i);
    		}
    	});
    
    	SystemManager.RunWithElevatedPrivilege(worker);
    }
