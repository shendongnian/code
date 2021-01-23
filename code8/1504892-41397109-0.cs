    public static class Tools
    {
        public static void FullScreenMode(this Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            Screen screen = Screen.FromPoint(Cursor.Position);
            form.Location = screen.Bounds.Location;
        }
    }
