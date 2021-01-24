    public class BezelButton : Button
    {
        public BezelButton()
        {
            Margin = new Thickness(1, 1, 0, 0);
            BorderThickness = new Thickness(0, 0, 2, 2);
            BorderBrush = new SolidColorBrush(Colors.DarkGray);
            Content = "Hello";
        }
    }
    public class HamburgerButton : BezelButton
    {
        public HamburgerButton()
        {
            // Default Font Height of Button
            double H = (double)Button.FontSizeProperty.GetMetadata(typeof(double)).DefaultValue;
            double A = H / 5;
            GeometryCollection DataHamburger = new GeometryCollection
        {
            new RectangleGeometry {Rect = new Rect{X = 0, Y = 0*A,  Width = 20, Height = A/2 }},
            new RectangleGeometry {Rect = new Rect{X = 0, Y = 2*A,  Width = 20, Height = A/2 }},
            new RectangleGeometry {Rect = new Rect{X = 0, Y = 4*A,  Width = 20, Height = A/2 }},
        };
            Path PathHamburger = new Path
            {
                Fill    = new SolidColorBrush(Colors.DarkGray),
                Stroke  = new SolidColorBrush(Colors.DarkGray),
                StrokeThickness = 1.0,
                Height  = H,
                Margin = new Thickness(4.5), // <==??? HOW TO AUTOMATICALLY CALCULATE??
                Data = new GeometryGroup { Children = DataHamburger }
            };
            Content = PathHamburger;
        }
