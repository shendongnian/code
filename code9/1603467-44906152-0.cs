    class Meme : Shape
    {
        public int used { get; set; }
        public string name { get; set; }
        protected override Geometry DefiningGeometry
        {
            get
            {
                return new EllipseGeometry(new Point(50, 50), 45, 20);
            }
        }
    }
