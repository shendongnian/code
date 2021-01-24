    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    /// <summary>
    /// Returns Geometry of line(s) from current node to next node(s)
    /// </summary>
    public class NodeToPathDataConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var nodes = values[0] as ObservableCollection<Node>;
            Node node = values[1] as Node;
            if (nodes != null && node != null && node.NextNodes != null)
            {
                // Create a StreamGeometry to draw line(s) from the current to the next node(s).
                StreamGeometry geometry = new StreamGeometry();
                using (StreamGeometryContext ctx = geometry.Open())
                {
                    foreach (string nextText in node.NextNodes)
                    {
                        Node nextNode = nodes.Single(n => n.Text == nextText);
                        ctx.BeginFigure(new Point(0, 0), false /* is filled */, false /* is closed */);
                        ctx.LineTo(new Point(nextNode.X - node.X, nextNode.Y - node.Y), true /* is stroked */, false /* is smooth join */);
                    }
                }
                // Freeze the geometry (make it unmodifiable) for additional performance benefits.
                geometry.Freeze();
                return geometry;
            }
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
