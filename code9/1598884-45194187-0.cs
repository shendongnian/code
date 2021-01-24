		public static ushort LOWORD(ulong l) { return (ushort)(l & 0xFFFF); }
		public static ushort HIWORD(ulong l) { return (ushort)((l >> 16) & 0xFFFF); }
		public static ushort GET_POINTERID_WPARAM(ulong wParam) { return LOWORD(wParam); }
		public static ushort GET_X_LPARAM(ulong lp) { return LOWORD(lp); }
		public static ushort GET_Y_LPARAM(ulong lp) { return HIWORD(lp); }
