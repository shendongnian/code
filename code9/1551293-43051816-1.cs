        var uiHostNoLaunch = new UIHostNoLaunch();
        var tipInvocation = (ITipInvocation)uiHostNoLaunch;
        tipInvocation.Toggle(GetDesktopWindow());
        Marshal.ReleaseComObject(uiHostNoLaunch);
       [ComImport, Guid("4ce576fa-83dc-4F88-951c-9d0782b4e376")]
       class UIHostNoLaunch
       {
       }
       [ComImport, Guid("37c994e7-432b-4834-a2f7-dce1f13b834b")]
       [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
       interface ITipInvocation
       {
           void Toggle(IntPtr hwnd);
       }
       [DllImport("user32.dll", SetLastError = false)]
       static extern IntPtr GetDesktopWindow();
     
