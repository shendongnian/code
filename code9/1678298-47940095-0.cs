    void DoStuff()
    {
        Window window = new Window();
    }
	public class Window : SafeHandleZeroOrMinusOneIsInvalid
	{
		public Window() : base(true)
		{
            // SDL_CreateWindow will create another `Window` instance internally!!
			SetHandle(SDL_CreateWindow("Hello", 400, 400, 800, 600, 0).handle);
		}
		protected override bool ReleaseHandle()
		{
			SDL_DestroyWindow(handle); // Since "this" won't work here (s. below)
			return true;
		}
		// Returns Window instance rather than IntPtr via the automatic SafeHandle creation
		[DllImport(_libName, CallingConvention = CallingConvention.Cdecl)]
		private static extern Window SDL_CreateWindow(
			[MarshalAs(UnmanagedType.LPStr)] string title, int x, int y, int w, int h, uint flags);
		// Accept Window instance rather than IntPtr (won't work out, s. below)
		[DllImport(_libName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void SDL_DestroyWindow(Window window);
	}
