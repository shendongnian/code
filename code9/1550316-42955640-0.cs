      public static class Extensions
    {
        private static System.Windows.Forms.Control StubButton;
        private static Point MouseDownLocation;
        public static void SetControlDraggable(this System.Windows.Forms.Control b)
        {
            b.MouseDown += b_MouseDown;
            b.MouseMove += b_MouseMove;
            StubButton = b;
        }
        public static void SetDraggable<T>(this T b)
            where T:System.Windows.Forms.Control
        {
            b.MouseDown += b_MouseDown;
            b.MouseMove += b_MouseMove;
            StubButton = b;
        }
        private static void b_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private static void b_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                StubButton.Left = e.X + StubButton.Left - MouseDownLocation.X;
                StubButton.Top = e.Y + StubButton.Top - MouseDownLocation.Y;
            }
        }
    }
