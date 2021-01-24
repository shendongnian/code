     private void btnCreatepath_Click(object sender, RoutedEventArgs e)
     {
         Path path = new Path();
         PathGeometry pathGeometry = new PathGeometry();
         PathFigure pathFigure = new PathFigure();
         ArcSegment arcSegment = new ArcSegment();
         arcSegment.IsLargeArc = true;
         arcSegment.Size = new Windows.Foundation.Size(25, 50);
         arcSegment.Point = new Windows.Foundation.Point(50, 0);
         arcSegment.RotationAngle = 180;
         pathFigure.IsClosed = true;
         pathFigure.Segments.Add(arcSegment);
         path.Data = pathGeometry;
         path.Stroke = new SolidColorBrush(Colors.Red);
         path.StrokeThickness = 2;
         path.Margin = new Thickness(40, 40, 0, 0);
         pathGeometry.Figures.Add(pathFigure);
         gridroot.Children.Add(path);
     }
