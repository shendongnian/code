		[StructLayout(LayoutKind.Explicit)]
		public unsafe struct STRUCT_SUB_ITEM
		{
			[FieldOffset(0)]
			public short Value;
			[FieldOffset(0)]
			public byte Type;
			[FieldOffset(1)]
			public byte Values;
		}
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct STRUCT_ITEM
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public STRUCT_SUB_ITEM[] Effect;
		}
