	class WindowContext
	{
		WNDCLASS wndclass;
		public IWindow CreateWindow(Point position, Size size)// this is called to create a window
		{
			IntPtr hInstance = processHandle.DangerousGetHandle();
			string szAppName = "ImGuiApplication~";
			wndclass.style = 0x0002 /*CS_HREDRAW*/ | 0x0001/*CS_VREDRAW*/;
			wndclass.lpfnWndProc = WindowProc;
		}
	}
