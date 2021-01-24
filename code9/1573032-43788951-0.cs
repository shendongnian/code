    public partial class Form1 : Form
    {
        private IntPtr selectedWindowHandler;    
        ...
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = new Cursor(Properties.Resources.aimImage.GetHicon());
            mousePressed = true;
            pictureBox_aimImage.Invalidate();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        { 
            mousePressed = false;
            invalidateAllWindows();
        }
        // this method for pictureBox1 which contain custom cursor
        // to choose window for draw border you must click on this box 
        // and drag to targwt window
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mousePressed)
            {
                Point point;
                WinApi.GetCursorPos(out point);
                IntPtr hWnd = Window.getHandler(point);
                if (hWnd.Equals(selectedWindowHandler))
                {                    
                    drawSelectionRectangle(selectedWindowHandler);
                    pictureBox_aimImage.Invalidate();
                } else
                {
                    selectedWindowHandler = hWnd;
                    invalidateAllWindows();
                }
            }
        }
        // when i once called InvalidateRect(...) not all border was cleared
        // i don't know why
        private static void invalidateAllWindows()
        {
            WinApi.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            WinApi.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            WinApi.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
        }     
   
        ...
        public static Rectangle getRectangle(IntPtr handler)
        {
            Rectangle rectangle;
            WinApi.GetWindowRect(handler, out rectangle);
            rectangle = new Rectangle(
                rectangle.Location,
                new Size(
                    rectangle.Size.Width - rectangle.Location.X,
                    rectangle.Size.Height - rectangle.Location.Y
                )
            );
            return rectangle;
        }
        public static void drawSelectionRectangle(IntPtr handler)
        {           
            //getting target window rectangle for GDI+
            Rectangle rect = getRectangle(handler);
            //getting context of desktop
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            using (g)
            {
                //drawing borders
                g.DrawRectangle(new Pen(Color.Red, 3), rect);
            }
        }
    }
