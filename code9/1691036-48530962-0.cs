	public static class PrinterUtilities
	{
		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GlobalFree(IntPtr handle);
		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GlobalLock(IntPtr handle);
		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GlobalUnlock(IntPtr handle);
		/// <summary>
		/// Grabs the data in arraylist and chucks it back into memory "Crank the suckers out"
		/// </summary>
		/// <param name="printerSettings"></param>
		/// <param name="filename"></param>
		public static void SetDevModeFromFile(PrinterSettings printerSettings, string filename)
		{
			IntPtr hDevMode = IntPtr.Zero;// a handle to our current DEVMODE
			IntPtr pDevMode = IntPtr.Zero;// a pointer to our current DEVMODE
			try
			{
				// Obtain the current DEVMODE position in memory
				hDevMode = printerSettings.GetHdevmode(printerSettings.DefaultPageSettings);
				// Obtain a lock on the handle and get an actual pointer so Windows won't move
				// it around while we're futzing with it
				pDevMode = GlobalLock(hDevMode);
				// Overwrite our current DEVMODE in memory with the one we saved.
				// They should be the same size since we haven't like upgraded the OS
				// or anything.
				var fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				var temparray = new byte[fs.Length];
				fs.Read(temparray, 0, temparray.Length);
				fs.Close();
				fs.Dispose();
				for (int i = 0; i < temparray.Length; ++i)
				{
					Marshal.WriteByte(pDevMode, i, temparray[i]);
				}
				// We're done futzing
				GlobalUnlock(hDevMode);
				// Tell our printer settings to use the one we just overwrote
				printerSettings.SetHdevmode(hDevMode);
				printerSettings.DefaultPageSettings.SetHdevmode(hDevMode);
				// It's copied to our printer settings, so we can free the OS-level one
				GlobalFree(hDevMode);
			}
			catch (Exception)
			{
				if (hDevMode != IntPtr.Zero)
				{
					GlobalUnlock(hDevMode);
					// And to boot, we don't need that DEVMODE anymore, either
					GlobalFree(hDevMode);
					hDevMode = IntPtr.Zero;
				}
			}
		}
	}
