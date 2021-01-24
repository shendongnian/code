	using (var stream = new FileStream("d:\\test.blob", FileMode.Create))
	{
		var security = new System.Security.AccessControl.FileSecurity();
		security.AddAccessRule(new FileSystemAccessRule(@"domain\user", FileSystemRights.Modify, AccessControlType.Allow));
		stream.SetAccessControl(security);
	
		using (var streamWriter = new StreamWriter(stream))
		{
			// ...
		}
	}
