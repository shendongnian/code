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
			if (hGlobal != IntPtr.Zero)
			{
				var lpwcstr = GlobalLock(hGlobal);
				if (lpwcstr != IntPtr.Zero)
				{
					int length = (int) GlobalSize(lpwcstr);
					Stream stream;
					unsafe
					{
						stream = new UnmanagedMemoryStream((byte*) lpwcstr, length);
					}
					using (var sw = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write), Encoding.UTF8))
					{
						//Clipboard text is in Encoding.Unicode == UTF-16LE
						using (var sr = new StreamReader(stream, Encoding.Unicode))
						{
							while (!sr.EndOfStream)
							{
								char c = (char) sr.Read();
								if (c != '\0' || !sr.EndOfStream)
									sw.Write(c);
							}
						}
					}
					GlobalUnlock(lpwcstr);
				}
			}
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
