    class shape
    {
        public Color color { get; set; }
        public int width { get; set; }
        public int startx { get; set; }
        public int starty { get; set; }
        public virtual void Draw(Graphics g)
        {
        }
    }
    class rectangle : shape
    {
        int length { get; set; }
        int width { get; set; }
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(color))
            {
                g.DrawRectangle(pen, new Rectangle(startx, starty, width, length));
            }
        }
    }
