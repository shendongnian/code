    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
	    FileIOPermission.QuickDemand(FileIOPermissionAccess.PathDiscovery, this.FullPath, false, true);
    	info.AddValue("OriginalPath", this.OriginalPath, typeof(string));
	    info.AddValue("FullPath", this.FullPath, typeof(string));
    }
