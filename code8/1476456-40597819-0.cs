    namespace GameMaps
    {
    public class MapPanel : Panel
    {
        private Map sourceMap;
        private Bitmap mapTexture;
        private Size mapSize;
        private Point mapPosition;
        private float dpiX, dpiY;
        private Point initialPosition;
        private Point initialMousePosition;
        private bool dragging;
        /* Constructors */
        public MapPanel() : base()
        {
            this.DoubleBuffered = true;
            this.sourceMap = null;
            this.dpiX = 96.0F; this.dpiY = 96.0F; // For now, this Application won't be DPI aware
        }
        public MapPanel(Panel targetPanel) : this()
        {
            // TO DO
        }
        /* Show a Map */
        public void ShowMap(Map map)
        {
            if (map == null)
                return;
            sourceMap = map;
            mapTexture = new Bitmap(map.MapTexture);
            mapTexture.SetResolution(dpiX, dpiY);
            mapSize = mapTexture.Size; // ?
            mapPosition = new Point(0, 0);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e);
            e.Graphics.PageUnit = GraphicsUnit.Pixel; // ?
            e.Graphics.PageScale = 1.0F; // ?
            
            if (sourceMap == null)
            {
                base.OnPaint(e);
                return;
            }
            e.Graphics.DrawImage(mapTexture, mapPosition.X, mapPosition.Y);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // base.OnMouseDown(e);
            if (sourceMap == null)
            {
                base.OnMouseDown(e);
                return;
            }
            if (dragging)
            {
                dragging = false;
                return;
            }
            else dragging = true;
            
            initialPosition.X = mapPosition.X;
            initialPosition.Y = mapPosition.Y;
            initialMousePosition.X = e.Location.X;
            initialMousePosition.Y = e.Location.Y;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //base.OnMouseMove(e);
            if (!dragging) return;
            mapPosition.X = e.X - initialMousePosition.X + initialPosition.X;
            mapPosition.Y = e.Y - initialMousePosition.Y + initialPosition.Y;
            if (mapPosition.X > 0)
                mapPosition.X = 0;
            else if (mapPosition.X < DisplayRectangle.Width - mapSize.Width)
                mapPosition.X = DisplayRectangle.Width - mapSize.Width;
            if (mapPosition.Y > 0)
                mapPosition.Y = 0;
            else if (mapPosition.Y < DisplayRectangle.Height - mapSize.Height)
                mapPosition.Y =  DisplayRectangle.Height - mapSize.Height;
            Invalidate(); // Force Repaint
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            // base.OnMouseLeave(e);
            dragging = false;
            // TO DO: Correct this
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            //base.OnMouseUp(e);
            dragging = false;
        }
    }
    }
