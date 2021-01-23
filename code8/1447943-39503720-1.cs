    public static bool GrantAccess(string fullPath)
	{
		DirectoryInfo info = new DirectoryInfo(fullPath);
		WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
		DirectorySecurity ds = info.GetAccessControl();
		ds.AddAccessRule(new FileSystemAccessRule(self.Name,
		FileSystemRights.FullControl,
		InheritanceFlags.ObjectInherit |
		InheritanceFlags.ContainerInherit,
		PropagationFlags.None,
		AccessControlType.Allow));
		info.SetAccessControl(ds);
		return true;
	}
