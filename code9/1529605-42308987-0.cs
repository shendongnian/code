     [DllImport("user32.dll", CharSet = CharSet.Auto)]
     static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);
     public static string GetWindowTextRaw(IntPtr hwnd)
     {
         // Allocate correct string length first
         int length = (int)SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
         StringBuilder sb = new StringBuilder(length + 1);
         SendMessage(hwnd, WM_GETTEXT, (IntPtr)sb.Capacity, sb);
         return sb.ToString();
     }
     public static void YourMethod() 
     {
         var desktop = AutomationElement.RootElement;
         //Use your process id to find the window instead of its name.
         //Replace the 0 with your processes process id.
         //The easiest way to get the process id will be to start the process yourself.
         var condition = new PropertyCondition(AutomationElement.ProcessId, 0);
         var window = desktop.FindFirst(System.Windows.Automation.TreeScope.Children, condition);
         var windowTitle = GetWindowTextRaw(window.NativeWindowHandle)
     }
