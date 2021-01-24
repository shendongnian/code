	internal class Win32
	{
		/*
		 * GetWindow() Constants
		 */
		public const int GW_HWNDFIRST			= 0;
		public const int GW_HWNDLAST			= 1;
		public const int GW_HWNDNEXT			= 2;
		public const int GW_HWNDPREV			= 3;
		public const int GW_OWNER				= 4;
		public const int GW_CHILD				= 5;
		public const int WM_NCCALCSIZE			= 0x83;
		public const int WM_WINDOWPOSCHANGING	= 0x46;
		public const int WM_PAINT				= 0xF;
		public const int WM_CREATE				= 0x1;
		public const int WM_NCCREATE			= 0x81;
		public const int WM_NCPAINT				= 0x85;
		public const int WM_PRINT				= 0x317;
		public const int WM_DESTROY				= 0x2;
		public const int WM_SHOWWINDOW			= 0x18;
		public const int WM_SHARED_MENU			= 0x1E2;
        public const int WM_LCLICK              = 0x202;
        public const int HC_ACTION				= 0;
		public const int WH_CALLWNDPROC			= 4;
		public const int GWL_WNDPROC			= -4;
        //Class name constant
        public const string MSCTLS_UPDOWN32 = "msctls_updown32";
        [ DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern int GetClassName(IntPtr hwnd, char[] className, int maxCount);
		[DllImport("User32.dll",CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);
	}
	#region SubClass Classing Handler Class
	internal class SubClass : System.Windows.Forms.NativeWindow
	{
		public delegate int SubClassWndProcEventHandler(ref System.Windows.Forms.Message m);
		public event SubClassWndProcEventHandler SubClassedWndProc;
		private bool IsSubClassed = false;
		public SubClass(IntPtr Handle, bool _SubClass)
		{
			base.AssignHandle(Handle);
			this.IsSubClassed = _SubClass;
		}
		public bool SubClassed
		{
			get{ return this.IsSubClassed; }
			set{ this.IsSubClassed = value; }
		}
		protected override void WndProc(ref Message m) 
		{
			if (this.IsSubClassed)
			{
				if (OnSubClassedWndProc(ref m) != 0)
					return;
			}
			base.WndProc(ref m);
		}
		private int OnSubClassedWndProc(ref Message m)
		{
			if (SubClassedWndProc != null)
			{
				return this.SubClassedWndProc(ref m);
			}
			return 0;
		}
	}
	#endregion
