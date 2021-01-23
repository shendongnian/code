    public class Tools
    {
        public static void FullScreenMode(Form @this)
        {
            @this.FormBorderStyle = FormBorderStyle.None;
            @this.WindowState = FormWindowState.Maximized;
            Screen screen = Screen.FromPoint(Cursor.Position);
            @this.Location = screen.Bounds.Location;
        }
    }
