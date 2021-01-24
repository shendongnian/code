    class Program
	{
		#region Win32
		// WinSCard APIs to be imported.
		[DllImport("WinScard.dll")]
		static extern int SCardEstablishContext(uint dwScope,
			IntPtr notUsed1,
			IntPtr notUsed2,
			out IntPtr phContext);
		[DllImport("WinScard.dll")]
		static extern int SCardReleaseContext(IntPtr phContext);
		[DllImport("WinScard.dll")]
		static extern int SCardConnect(IntPtr hContext,
			string cReaderName,
			uint dwShareMode,
			uint dwPrefProtocol,
			ref IntPtr phCard,
			ref IntPtr ActiveProtocol);
		[DllImport("WinScard.dll")]
		static extern int SCardDisconnect(IntPtr hCard, int Disposition);
		[DllImport("WinScard.dll", EntryPoint = "SCardListReadersA", CharSet = CharSet.Ansi)]
		static extern int SCardListReaders(
		  IntPtr hContext,
		  byte[] mszGroups,
		  byte[] mszReaders,
		  ref UInt32 pcchReaders);
		#endregion
		static void Main(string[] args)
		{
			IntPtr hContext = IntPtr.Zero;
			while (true)
			{
				SmartCardInserted(hContext);
				System.Threading.Thread.Sleep(10);
			}
			SCardReleaseContext(hContext);
		}
		internal static bool SmartCardInserted(IntPtr hContext)
		{
			bool cardInserted = false;
			try
			{
				List<string> readersList = new List<string>();
				int ret = 0;
				uint pcchReaders = 0;
				int nullindex = -1;
				char nullchar = (char)0;
				// Establish context.
				if(hContext == IntPtr.Zero)
					ret = SCardEstablishContext(2, IntPtr.Zero, IntPtr.Zero, out hContext);
				// First call with 3rd parameter set to null gets readers buffer length.
				ret = SCardListReaders(hContext, null, null, ref pcchReaders);
				if(ret == 0x80100003) // SCARD_E_INVALID_HANDLE = 0x80100003, // The supplied handle was invalid
				{
					try
					{
						SCardReleaseContext(hContext);
					}
					catch {}
					finally
					{
						hContext = IntPtr.Zero;
					}
					return false;
				}
				
				byte[] mszReaders = new byte[pcchReaders];
				// Fill readers buffer with second call.
				ret = SCardListReaders(hContext, null, mszReaders, ref pcchReaders);
				// Populate List with readers.
				ASCIIEncoding ascii = new ASCIIEncoding();
				string currbuff = ascii.GetString(mszReaders);
				int len = (int)pcchReaders;
				if (len > 0)
				{
					while (currbuff[0] != nullchar)
					{
						nullindex = currbuff.IndexOf(nullchar);   // Get null end character.
						string reader = currbuff.Substring(0, nullindex);
						readersList.Add(reader);
						len = len - (reader.Length + 1);
						currbuff = currbuff.Substring(nullindex + 1, len);
					}
				}
				// We have list of readers, check for cards.
				IntPtr phCard = IntPtr.Zero;
				IntPtr ActiveProtocol = IntPtr.Zero;
				int result = 0;
				foreach (string readerName in readersList)
				{
					try
					{
						result = SCardConnect(hContext, readerName, 2, 3, ref phCard, ref ActiveProtocol);
						if (result == 0)
						{
							cardInserted = true;
							break;
						}
					}
					finally
					{
						SCardDisconnect(phCard, 0);
					}
				}
			}
			return cardInserted;
		}
	}
