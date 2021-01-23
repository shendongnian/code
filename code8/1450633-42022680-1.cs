    [StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct UNICODE_STRING
	{
		private IntPtr _dummy; // the two ushorts seem to be padded with 4 bytes in 64bit mode only
		/// <summary>
		/// The length, in bytes, of the string stored in Buffer. If the string is null-terminated, Length does not include the trailing null character.
		/// </summary>
		public ushort Length
		{
			get { return (ushort)Marshal.ReadInt16(this, 0); }
		}
		/// <summary>
		/// The length, in bytes, of Buffer.
		/// </summary>
		public ushort MaximumLength
		{
			get { return (ushort)Marshal.ReadInt16(this, 2); }
		}
		public IntPtr Buffer;
	}
