    class PixelEditor : Panel
    {
        public Color DrawColor { get; set; }
        public Color GridColor { get; set; }
        int pixelSize = 8;
        public int PixelSize
        {
            get { return pixelSize; }
            set
            {
                pixelSize = value;
                Invalidate();
            }
        }
        public Bitmap TgtBitmap { get; set; }
        public Point TgtMousePos { get; set; }
        Point lastPoint = Point.Empty;
        PictureBox aPBox = null;
        public PictureBox APBox {
            get { return aPBox; }
            set
            {
                if (value == null) return;
                aPBox = value;
                aPBox.MouseClick -=APBox_MouseClick;
                aPBox.MouseClick +=APBox_MouseClick;
            }
        }
        private void APBox_MouseClick(object sender, MouseEventArgs e)
        {
            TgtMousePos = e.Location;
            Invalidate();
        }
        public PixelEditor()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            GridColor = Color.DimGray;
            DrawColor = Color.Red;
            PixelSize = 10;
            TgtMousePos = Point.Empty;
            if (APBox != null && APBox.Image != null)
                TgtBitmap = (Bitmap)APBox.Image;
            MouseClick +=PixelEditor_MouseClick;
            MouseMove +=PixelEditor_MouseMove;
            Paint +=PixelEditor_Paint;
        }
        private void PixelEditor_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode) return;
            Graphics g = e.Graphics;
            int c = ClientSize.Width / PixelSize;
            int r = ClientSize.Height / PixelSize;
            if (TgtMousePos.X < 0 || TgtMousePos.Y < 0) return;
            for (int x = 0; x < c; x++)
                for (int y = 0; y < r; y++)
                {
                    int sx = TgtMousePos.X + x;
                    int sy = TgtMousePos.Y + y;
                    if (sx > TgtBitmap.Width  || sy > TgtBitmap.Height) return;
                    Color col = TgtBitmap.GetPixel(sx, sy);
                    using (SolidBrush b = new SolidBrush(col))
                    {
                        g.FillRectangle(b, new Rectangle(x * PixelSize, y * PixelSize, 
                                                         PixelSize, PixelSize));
                        g.DrawRectangle(Pens.Black, new Rectangle(x * PixelSize,
                                        y * PixelSize, PixelSize - 1, PixelSize - 1));
                    }
                }
        }
        private void PixelEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            int x = TgtMousePos.X + e.X / PixelSize;
            int y = TgtMousePos.Y + e.Y / PixelSize;
            if (new Point(x, y) == lastPoint) return;
            Bitmap bmp = (Bitmap)APBox.Image;
            bmp.SetPixel(x,y, DrawColor);
            APBox.Image = bmp;
            Invalidate();
            lastPoint = new Point(x, y);
        }
        private void PixelEditor_MouseClick(object sender, MouseEventArgs e)
        {
            int x = TgtMousePos.X + e.X / PixelSize;
            int y = TgtMousePos.Y + e.Y / PixelSize;
            Bitmap bmp = (Bitmap)APBox.Image;
            bmp.SetPixel(x,y, DrawColor);
            APBox.Image = bmp;
            Invalidate();
        }
    }
