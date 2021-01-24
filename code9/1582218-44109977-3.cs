	[DllImport("user32.dll")]
	private static extern IntPtr GetClipboardData(uint uFormat);
	[DllImport("user32.dll")]
	private static extern bool IsClipboardFormatAvailable(uint format);
	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool OpenClipboard(IntPtr hWndNewOwner);
	[DllImport("user32.dll", SetLastError = true)]
	private static extern bool CloseClipboard();
	[DllImport("kernel32.dll")]
	private static extern IntPtr GlobalLock(IntPtr hMem);
	[DllImport("kernel32.dll")]
	private static extern bool GlobalUnlock(IntPtr hMem);
	[DllImport("kernel32.dll")]
	private static extern UIntPtr GlobalSize(IntPtr hMem);
	private const uint CF_UNICODETEXT = 13;
	//Write the clipboard to a text file without having to first convert it to a string.
	//This avoids OutOfMemoryException for large clipboards
	public static bool WriteClipboardTextToFile(string filename)
	{
		try
		{
			if (!IsClipboardFormatAvailable(CF_UNICODETEXT) || !OpenClipboard(IntPtr.Zero))
				return false;
		}
		catch
		{
			return false;
		}
		try
		{
			var hGlobal = GetClipboardData(CF_UNICODETEXT);
			if (hGlobal == IntPtr.Zero)
				return false;
			var lpwcstr = GlobalLock(hGlobal);
			if (lpwcstr == IntPtr.Zero)
				return false;
			int length = (int) GlobalSize(lpwcstr);
			Stream stream;
			unsafe
			{
				stream = new UnmanagedMemoryStream((byte*) lpwcstr, length);
			}
			const int bufSize = 4096;
			var buffer = new char[bufSize];
			using (var sw = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write), Encoding.UTF8))
			{
				//Clipboard text is in Encoding.Unicode == UTF-16LE
				using (var sr = new StreamReader(stream, Encoding.Unicode))
				{
					while (!sr.EndOfStream)
					{
						int charsRead = sr.ReadBlock(buffer, 0, bufSize);
						if (charsRead > 0)
						{
							if (sr.EndOfStream && buffer[charsRead - 1] == '\0')
								charsRead--; //don't write out final null terminator to file
							sw.Write(buffer, 0, charsRead);
						}
					}
				}
			}
			GlobalUnlock(lpwcstr);
		}
		catch
		{
			return false;
		}
		finally
		{
			try
			{
				CloseClipboard();
			}
			catch
			{
				//ignore
			}
		}
		return true;
	}
