    class draw
    {
        public static void circle(int x, int y, int width, int height, Canvas cv)
        {
            Ellipse circle = new Ellipse()
            {
                Width = width,
                Height = height,
                Stroke = Brushes.Red,
                StrokeThickness = 6
            };
            cv.Children.Add(circle);
            circle.SetValue(Canvas.LeftProperty, (double)x);
            circle.SetValue(Canvas.TopProperty, (double)y);
        }
    }
