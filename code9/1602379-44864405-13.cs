        public void AddPath()
        {
            var canvas = new Canvas();
            
            var path = new Path()
            {
                Fill = new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2.0
            };
            var geometry = new PathGeometry();
            geometry.Figures.Add(new PathFigure(
                new Point(0, 0),
                new List<BezierSegment>()
                {
                    new BezierSegment(
                        new Point(0, 0),
                        new Point(100, 0),
                        new Point(50, -100),
                        true)
                },
                false));
            
            path.Data = geometry;
            canvas.Children.Add(path);
            _stackPanel.Children.Add(canvas);
        }
