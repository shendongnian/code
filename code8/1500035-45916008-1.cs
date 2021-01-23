    public enum SyncStatus { Off, Unknown, Syncing, Synced, Error }
    
    private SyncStatus CheckIfSync(DirectoryInfo di)
    {
    	ExtractIconInfo IcoInfo = new ExtractIconInfo(di);
    	//IcoInfo.Icon.ToBitmap().Save(@"C:\Temp\icons\" + IcoInfo.IconName + ".png");
    	//IcoInfo.IconWithOverlay.ToBitmap().Save(@"C:\Temp\icons\" + IcoInfo.IconName + "_over.png");
    	if (IcoInfo != null && IcoInfo.IconWithOverlayHash.Length > 0)
    	{
    		Version osVersion = Environment.OSVersion.Version;
    		string isSynced;
    		string isSyncing;
    		string isOff;
    		double version = osVersion.Major + ((double)osVersion.MajorRevision / 10);
    		if (version > 6.1d)
    		{
    			isSynced = "Ÿ/º¼ñu‡gèI—ƒH%Ú";
    			isSyncing = "¹|ÁtÛÖÒ >…Ôøy";
    			isOff = "zíC’©,ígÌÕ0÷";
    		}
    		else
    		{
    			isSynced = "Š#cÍp:µº˜}Þ¯O¶";
    			isSyncing = "¹Î8Œðù(ŠÜîÆDØ;        ª";
    			isOff = "zíC’©,ígÌÕT0÷";
    		}
    		if (IcoInfo.IconWithOverlayHash == isSynced) return SyncStatus.Synced;
    		else if (IcoInfo.IconWithOverlayHash == isSyncing) return SyncStatus.Syncing;
    		else if (IcoInfo.IconWithOverlayHash == isOff) return SyncStatus.Off;
    		else return SyncStatus.Unknown;
    	}
    	else return SyncStatus.Unknown;
    }
