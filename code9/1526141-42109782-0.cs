    using System.Windows;
    using System.Windows.Forms; // Reference System.Drawing
    
    [...]
    public void SetWindowScreen(Window window, Screen screen)
    {
        if (screen != null)
        {
            if (!window.IsLoaded)
            {
                window.WindowStartupLocation = WindowStartupLocation.Manual;
            }
            var workingArea = screen.WorkingArea;
            window.Left = workingArea.Left;
            window.Top = workingArea.Top;
        }
    }
    public Screen GetWindowScreen(Window window)
    {
        return Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(window).Handle);
    }
