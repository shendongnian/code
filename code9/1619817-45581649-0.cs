    public class TriangleSliderUC : PictureBox
    {
        public double Hypotenuse
        {
            get { return hypotenuse; }
            set
            {
                hypotenuse = value;
                UpdateTriangle();
            }
        }
        public double FinalPoint
        {
            get { return finalPoint; }
            set
            {
                finalPoint = value;
                UpdateTriangle();
            }
        }
        private PointF[] triangle = { new Point(0, 0), new Point(0, 0), new Point(0, 0) };
        private double hypotenuse;
        private double finalPoint;
        public TriangleSliderUC()
        {
            UpdateTriangle();
        }
        public void UpdateTriangle()
        {
            triangle[0] = new PointF((int)finalPoint, (int)(hypotenuse * 0.5f));
            triangle[1] = new PointF(0, 0); 
            triangle[2] = new PointF(0, (int)hypotenuse);
            // Create a new image with the current control dimensions
            Bitmap image = new Bitmap(Width, Height);
            // Create a grahics object, draw the triangle
            var g = Graphics.FromImage(image);
            g.FillPolygon(Brushes.Orange, triangle);
            // Update the controls image with the newly created image
            this.Image = image;
        }
    }
