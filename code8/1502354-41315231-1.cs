    [System.Runtime.InteropServices.DllImport("User32.dll")]
    static extern bool MoveWindow(IntPtr h, int x, int y, int width, int height, bool redraw);
    private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
    {
        e.DrawBackground();
        e.DrawBorder();
        e.DrawText();
        var t = (ToolTip)sender;
        var h = t.GetType().GetProperty("Handle",
          System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var handle = (IntPtr)h.GetValue(t);
        var c = e.AssociatedControl;
        var location = c.Parent.PointToScreen(new Point(c.Right - e.Bounds.Width, c.Bottom));
        MoveWindow(handle, location.X, location.Y, e.Bounds.Width, e.Bounds.Height, false);
    }
