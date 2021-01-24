    using SDL_Window = System.IntPtr;
	public class Window : SafeHandleZeroOrMinusOneIsInvalid
	{
	    private Window(IntPtr handle) : base(true)
		{
		    SetHandle(handle);
		}
	
		public Window() : this(SDL_CreateWindow("Hello", 400, 400, 800, 600, 0)) { }
		protected override bool ReleaseHandle()
		{
			SDL_DestroyWindow(handle);
			return true;
		}
		[DllImport(_libName, CallingConvention = CallingConvention.Cdecl)]
		private static extern SDL_Window SDL_CreateWindow(
			[MarshalAs(UnmanagedType.LPStr)] string title, int x, int y, int w, int h, uint flags);
		[DllImport(_libName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void SDL_DestroyWindow(SDL_Window window);
	}
