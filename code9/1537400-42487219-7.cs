    internal sealed class AdvancedListView : ListView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
            {
                SetWindowTheme(Handle, "explorer", null);
            }
        }
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
    }
