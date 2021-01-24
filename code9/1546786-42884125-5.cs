	private static void TestShellFolder()
	{
		object recycleBinTemp;
		ShellFolderUtilities.BindToCsidl(ShellFolderUtilities.CSIDL_BITBUCKET, typeof(IShellFolder).GUID, out recycleBinTemp);
		var recycleBin = (IShellFolder)recycleBinTemp;
		var pids = new List<PITEMID_CHILD>();
		try
		{
			foreach (PITEMID_CHILD pidl in recycleBin.Enumerate())
			{
				// Remember to free the pidl!
				string str;
				using (var ret = new STRRET { uType = STRRET_TYPE.CSTR })
				{
					recycleBin.GetDisplayNameOf(pidl, 0, ret);
					str = ret.ToString(pidl);
				}
				// Some condition to include/exclude...
				if (pids.Count < 10)
				{
					Console.WriteLine(str);
					pids.Add(pidl);
				}
				else
				{
					Marshal.FreeCoTaskMem(pidl.Ptr);
				}
			}
			var pids2 = pids.ToArray();
			object cmTemp;
			recycleBin.GetUIObjectOf(IntPtr.Zero, pids2.Length, pids2, typeof(IContextMenu).GUID, IntPtr.Zero, out cmTemp);
			var cm = (IContextMenu)cmTemp;
			// To see verbs
			//var verbsAnsi = ContextMenuUtilities.GetVerbs(cm, true);
			//var verbsUnicode = ContextMenuUtilities.GetVerbs(cm, false);
			var cmd = new CMINVOKECOMMANDINFOEX
			{
				cbSize = Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX)),
				fMask = 0x00000400 /* CMIC_MASK_FLAG_NO_UI */,
				lpVerb = "delete",
			};
			cm.InvokeCommand(ref cmd);
		}
		finally
		{
			foreach (var pid in pids)
			{
				Marshal.FreeCoTaskMem(pid.Ptr);
			}
		}
	}
