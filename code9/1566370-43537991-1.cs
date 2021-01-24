        protected override void OnStartup(StartupEventArgs e)
        {
            if (Environment.OSVersion.Version >= new Version(6, 3, 0)) // win 8.1 added support for per monitor dpi
            {
                if (Environment.OSVersion.Version >= new Version(10, 0, 15063)) // win 10 creators update added support for per monitor v2
                {
                     NativeMethods.SetProcessDpiAwarenessContext((int)NativeMethods.DPI_AWARENESS_CONTEXT.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
                }
                else NativeMethods.SetProcessDpiAwareness(NativeMethods.PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);
            }
            else NativeMethods.SetProcessDPIAware();
            base.OnStartup(e);
        }
