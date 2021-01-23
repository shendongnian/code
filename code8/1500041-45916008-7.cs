    public enum SyncStatus { Off, Unknown, Syncing, Synced, SharedSyncing, SharedSynced, Error }
    
    private SyncStatus CheckIfSync(DirectoryInfo di)
    {
    	ExtractIconInfo IcoInfo = new ExtractIconInfo(di);
    	if (IcoInfo != null)
    	{
    		if (IcoInfo.IconOverlayGuid == Guid.Empty) return SyncStatus.Off;
    		else if (IcoInfo.IconOverlayGuid == new Guid("{BBACC218-34EA-4666-9D7A-C78F2274A524}")) return SyncStatus.Error;
    		else if (IcoInfo.IconOverlayGuid == new Guid("{F241C880-6982-4CE5-8CF7-7085BA96DA5A}")) return SyncStatus.Synced;
    		else if (IcoInfo.IconOverlayGuid == new Guid("{A0396A93-DC06-4AEF-BEE9-95FFCCAEF20E}")) return SyncStatus.Syncing;
    		else if (IcoInfo.IconOverlayGuid == new Guid("{5AB7172C-9C11-405C-8DD5-AF20F3606282}")) return SyncStatus.SharedSynced;
    		else if (IcoInfo.IconOverlayGuid == new Guid("{A78ED123-AB77-406B-9962-2A5D9D2F7F30}")) return SyncStatus.SharedSyncing;
    		else return SyncStatus.Unknown;
    	}
    	else return SyncStatus.Unknown;
    }
