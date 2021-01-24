    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Shapes;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Data;
    
    namespace GridNineExperiment
    {
        public class HamburgerButton : Button
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
                    Fill = new SolidColorBrush(Colors.Black),
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 1.0,
                    Data = new GeometryGroup { Children = DataHamburger }
                };
    
                Content = PathHamburger;
            }
        }
