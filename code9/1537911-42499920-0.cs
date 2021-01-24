    /// <summary>
    /// Provides importing API functions and methods.
    /// </summary>
    internal class APIHelper
    {
    /// <summary>
    /// Provides importing API functions and methods.
    /// </summary>
    internal APIHelper()
    {
    }
    #region Imported DLL's
    /// <summary>
    /// Retrieves the device context for the entire window.
    /// </summary>
    /// <param name="hWnd">A handle to the window.</param>
    /// <returns>The handle to the device context for the window.</returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr GetWindowDC(IntPtr hWnd);
    /// <summary>
    /// Releases a device context.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
    /// <param name="hDC">A handle to the DC to be released.</param>
    /// <returns>The return value indicates whether the DC was released. If the DC was released, the return value is 1 otherwise 0.</returns>
    [DllImport("user32.dll")]
    internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    /// <summary>
    /// Updates the specified rectangle or region in a window's client area.
    /// </summary>
    /// <param name="hWnd">A handle to the window to be redrawn.</param>
    /// <param name="lprc">A pointer to a RECT structure containing the coordinates, in device units, of the update rectangle. This parameter is ignored if the hrgnUpdate parameter identifies a region.</param>
    /// <param name="hrgn">A handle to the update region. If both the hrgnUpdate and lprcUpdate parameters are NULL, the entire client area is added to the update region.</param>
    /// <param name="flags">One or more redraw flags. This parameter can be used to invalidate or validate a window, control repainting, and control which windows are affected by RedrawWindow.</param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
    #endregion
    #region Methods and Functions
    #endregion
    }
