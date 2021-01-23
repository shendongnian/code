    public static Cursor ActuallyLoadCursor(String path)
        {
            return new Cursor(LoadCursorFromFile(path));
        }
        [DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string fileName);
    Button btn = new Button();
    btn.MouseLeave += Btn_MouseLeave;
    btn.Cursor = ActuallyLoadCursor("Cursor.cur");
    private static void Btn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
