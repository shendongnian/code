	public static void ExplorerOverrideDelete (string ext)
	{
		if (!IsAdministrator()) {
			MessageBox.Show(
			    "ExplorerOverrideDelete(): Rerun program as Admin",
			    "Access Denied"
		}
		
		if (!ext.StartsWith(".")) {
			ext = "." + ext;
		}
		var keyroot     = Registry.CurrentUser.OpenSubKey(
			@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts", 
		    RegistryKeyPermissionCheck.ReadWriteSubTree);
					
		if (keyroot == null)
			return;
					
		keyroot.GetAccessControl(System.Security.AccessControl.AccessControlSections.All);
		
		// /keyroot.GetAccessControl(
		//     System.Security.AccessControl.AccessControlSections.All
		//  & ~System.Security.AccessControl.AccessControlSections.Audit);
		try {
			keyroot.DeleteSubKeyTree(ext);
		}
		catch(Exception e) {
			keyroot.Close();
			hivereg.Close();			
		    MessageBox.Show(e.Message);
		}
		
		keyroot.Close();
		hivereg.Close();
	}
	
	public static bool IsAdministrator()
	{
		System.Security.Principal.WindowsIdentity identity
			= System.Security.Principal.WindowsIdentity.GetCurrent();
		System.Security.Principal.WindowsPrincipal principal
			= new System.Security.Principal.WindowsPrincipal(identity);
		return principal.IsInRole(
			System.Security.Principal.WindowsBuiltInRole.Administrator
		);
	}
