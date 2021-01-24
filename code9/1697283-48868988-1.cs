        pnlReport.AutoScrollPosition = new Point(0, 0);
        public void DrawControl(Control control, Bitmap bitmap)
        {
            control.DrawToBitmap(bitmap, control.Bounds);
            foreach (Control childControl in control.Controls)
            {
                DrawControl(childControl, bitmap);
            }
        }
       
        public void SaveBitmap(string filename)
        {
            var size = myControl.PreferredSize;
            var height = size.Height;
            Bitmap bmp = new Bitmap(this.myControl.Width, height);
            this.myControl.DrawToBitmap(bmp, new Rectangle(0, 0, this.myControl.Width, height));
            foreach (Control control in myControl.Controls)
            {
                DrawControl(control, bmp);
            }
            bmp.Save(filename, ImageFormat.Jpeg);
            bmp.Dispose();
        }
