	private static void TestShellItem()
	{
		IShellItem recyleBin;
		string str;
		IntPtr ptr = IntPtr.Zero;
		int res;
		//// From Windows 7
		//res = ShellItemUtilities.SHGetKnownFolderItem(ShellItemUtilities.FOLDERID_RecycleBinFolder, 0, IntPtr.Zero, typeof(IShellItem).GUID, out recyleBin);
		//if (res < 0)
		//{
		//    Marshal.ThrowExceptionForHR(res);
		//}
		// Windows >= Vista equivalent
		var pidl = default(PIDLIST_ABSOLUTE);
		try
		{
			res = ShellItemUtilities.SHGetKnownFolderIDList(ShellItemUtilities.FOLDERID_RecycleBinFolder, 0, IntPtr.Zero, out pidl);
			if (res < 0)
			{
				Marshal.ThrowExceptionForHR(res);
			}
			res = ShellItemUtilities.SHCreateItemFromIDList(pidl, typeof(IShellItem).GUID, out recyleBin);
			if (res < 0)
			{
				Marshal.ThrowExceptionForHR(res);
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(pidl.Ptr);
		}
		//// Example of use of GetDisplayName
		//try
		//{
		//    recyleBin.GetDisplayName(2, out ptr);
		//    str = Marshal.PtrToStringUni(ptr);
		//}
		//finally
		//{
		//    if (ptr != IntPtr.Zero)
		//    {
		//        Marshal.FreeCoTaskMem(ptr);
		//        ptr = IntPtr.Zero;
		//    }
		//}
		var pids = new List<PIDLIST_ABSOLUTE>();
		try
		{
			foreach (IShellItem si in recyleBin.Enumerate())
			{
				try
				{
					si.GetDisplayName(0, out ptr);
					str = Marshal.PtrToStringUni(ptr);
					// Some condition to include/exclude...
					if (pids.Count < 10)
					{
						Console.WriteLine(str);
						// Remember to free the pidl!
						res = ShellItemUtilities.SHGetIDListFromObject(si, out pidl);
						if (res < 0)
						{
							Marshal.ThrowExceptionForHR(res);
						}
						pids.Add(pidl);
					}
				}
				finally
				{
					if (ptr != IntPtr.Zero)
					{
						Marshal.FreeCoTaskMem(ptr);
						ptr = IntPtr.Zero;
					}
				}
			}
			var pids2 = pids.ToArray();
			IShellItemArray sia;
			res = ShellItemUtilities.SHCreateShellItemArrayFromIDLists(pids2.Length, pids2, out sia);
			if (res < 0)
			{
				Marshal.ThrowExceptionForHR(res);
			}
			object cmTemp;
			sia.BindToHandler(IntPtr.Zero, ShellItemUtilities.BHID_SFUIObject, typeof(IContextMenu).GUID, out cmTemp);
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
		//// Verb executed one by one
		//foreach (var item in recyleBin.Enumerate())
		//{
		//    object cmTemp;
		//    item.BindToHandler(IntPtr.Zero, ShellItemUtilities.BHID_SFUIObject, typeof(IContextMenu).GUID, out cmTemp);
		//    var cm = (IContextMenu)cmTemp;
		////// To see verbs
		////    var verbsAnsi = ContextMenuUtilities.GetVerbs(cm, true);
		////    var verbsUnicode = ContextMenuUtilities.GetVerbs(cm, false);
		//    var cmd = new CMINVOKECOMMANDINFOEX
		//    {
		//        cbSize = Marshal.SizeOf(typeof(CMINVOKECOMMANDINFOEX)),
		//        fMask = 0x00000400 /* CMIC_MASK_FLAG_NO_UI */,
		//        lpVerb = "delete",
		//    };
		//    cm.InvokeCommand(ref cmd);
		//}
	}
