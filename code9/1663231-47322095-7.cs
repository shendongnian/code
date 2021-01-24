		[StructLayout(LayoutKind.Explicit)]
		public struct STRUCT_SUB_ITEM
		{
			[FieldOffset(0)]
			public short Value;
			[FieldOffset(0)]
			public byte Type;
			[FieldOffset(1)]
			public byte Values;
		}
		[StructLayout(LayoutKind.Sequential)]
		public struct STRUCT_ITEM
		{
            short index;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			public STRUCT_SUB_ITEM[] Effect;
		}
