    public class CrossHair : Grid
        {
            public string LineName { get; set; }
            
            /// <summary>
            /// Draws the crosshair at the given point
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            static public CrossHair DrawCrossHair(double x, double y)
            {
                var crosshair = new CrossHair(); // to contain the cross hair
                var line1 = new Line();
                var line2 = new Line();
                var line3 = new Line();
                var line4 = new Line();
                line1.Stroke = line2.Stroke = line3.Stroke = line4.Stroke = new SolidColorBrush(Colors.Yellow);
                line1.StrokeThickness = line2.StrokeThickness = line3.StrokeThickness = line4.StrokeThickness = 2;
    
                line1.X1 = x - 5;
                line1.Y1 = y;
                line1.X2 = x - 2;
                line1.Y2 = y;
    
                line2.X1 = x;
                line2.Y1 = y + 5;
                line2.X2 = x;
                line2.Y2 = y + 2;
    
                line3.X1 = x + 2;
                line3.Y1 = y;
                line3.X2 = x + 5;
                line3.Y2 = y;
    
                line4.X1 = x;
                line4.Y1 = y - 2;
                line4.X2 = x;
                line4.Y2 = y - 5;
    
                crosshair.Children.Add(line1);
                crosshair.Children.Add(line2);
                crosshair.Children.Add(line3);
                crosshair.Children.Add(line4);
    
                return crosshair;
            }
        }
