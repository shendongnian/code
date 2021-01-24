    public static IEnumerable<Rect> ComputeIntersectingSegments(Geometry geometry, double y, double width)
    {
        // Add a geometry line to compute intersections.
        // A geometry must not be 0 thickness for combination to be meaningful.
        // So we widen the line by a very small size
        var line = new LineGeometry(new Point(0, y), new Point(width, y)).GetWidenedPathGeometry(new Pen(null, 0.01));
        // Intersect the line with input geometry and compute intersections
        var combined = Geometry.Combine(line, geometry, GeometryCombineMode.Intersect, null);
        foreach (var figure in combined.Figures)
        {
            // the resulting figure can be a complex thing
            // we just want the bounding box
            yield return new PathGeometry(new PathFigure[] { figure }).Bounds;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // use a canvas to display shape and intersections
            var canvas = new Canvas();
            Content = canvas;
            // your polygon can be built as a geometry for example like this:
            // var myPolygon = Geometry.Parse("M50,50 L50,165 L140,165 L140,120 L70,120 L80,70 L140,70 L140,50");
            // build a 'o' shape for testing, add it to the canvas
            var circle1 = new EllipseGeometry(new Point(100, 100), 70, 70);
            var circle2 = new EllipseGeometry(new Point(100, 100), 40, 40);
            // exclude mode will compute the 'o' shape ...
            var oGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, circle1, circle2);
            var oPath = new Path();
            oPath.Stroke = Brushes.Black;
            oPath.Fill = Brushes.LightSeaGreen;
            oPath.StrokeThickness = 2;
            oPath.Data = oGeometry;
            canvas.Children.Add(oPath);
            // test many heights
            for (int y = 0; y < Height; y += 25)
            {
                foreach (var segment in ComputeIntersectingSegments(oGeometry, y, Width))
                {
                    // for our sample, we add each segment to the canvas
                    // Height is irrelevant, we use 2 for tests
                    var line = new Rectangle();
                    Canvas.SetLeft(line, segment.X);
                    Canvas.SetTop(line, segment.Y);
                    line.Width = segment.Width;
                    line.Height = 2;
                    line.Stroke = Brushes.Red;
                    line.StrokeThickness = 1;
                    canvas.Children.Add(line);
                }
            }
        }
    }
