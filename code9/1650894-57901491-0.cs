	ManagementObjectSearcher ms = new ManagementObjectSearcher(_Scope, new ObjectQuery("select * from UWF_Volume where VolumeName = \"" + volId + "\" AND CurrentSession=\"False\""));
	ManagementObjectCollection c = ms.Get();
	UInt32 res = 1;
	foreach (ManagementObject mo in c)
	{
		// entry found: do it with WMI
		res = (UInt32)mo.InvokeMethod(newState ? "Protect" : "Unprotect", new object[] { });
	}
	if (c.Count == 1 && res == 0)
		// message: success
	if (c.Count == 0)
	{
		// no entry found: invoke cmd
		ProcessStartInfo info = new ProcessStartInfo("uwfmgr.exe", "volume " + (newState ? "Protect" : "Unprotect") + @" \\?\" + volId);
		Process process = new Process();
		info.Verb = "runas";  //needs admin
		process.StartInfo = info;
		process.Start();
		process.WaitForExit();
	}
