        public void AddPolygon()
        {
            var polygon = new Polygon()
            {
                Fill = new SolidColorBrush(Colors.Red),
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2.0
            };
            polygon.Points.Add(new Point(0, 0));
            polygon.Points.Add(new Point(10, 0));
            polygon.Points.Add(new Point(5, -10));
            _stackPanel.Children.Add(polygon);
        }
