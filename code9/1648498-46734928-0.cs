    foreach (string directory in System.IO.Directory.GetDirectories(@"path", "*", SearchOption.AllDirectories))
    {
	foreach (string file in System.IO.Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly))
	{
		DirectorySecurity DS = System.IO.Directory.GetAccessControl(directory, AccessControlSections.Access);
		FileSecurity FS = new FileSecurity();
		System.IO.FileInfo FI = new FileInfo(file);
		foreach (FileSystemAccessRule rule in DS.GetAccessRules(true, false, typeof(NTAccount)))
		{
			FileSystemAccessRule nRule = new FileSystemAccessRule(rule.IdentityReference, rule.FileSystemRights, InheritanceFlags.None, rule.PropagationFlags, rule.AccessControlType);
			FS.AddAccessRule(nRule);
		}
		FI.SetAccessControl(FS);
	}
    }
