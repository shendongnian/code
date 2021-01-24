    public class Item
    {
        public double Left { get; set; }
        public double Top { get; set; }
    }
    public class ShapeItem : Item
    {
        public Shape Shape { get; set; }
    }
    public class TextItem : Item
    {
        public string Text { get; set; }
    }
    public partial class MainWindow : Window
    {
        public List<object> Items { get; } = new List<object>
        {
            new ShapeItem { Shape = new Rectangle { Width = 100, Height = 100, Fill= Brushes.Yellow, Stroke = Brushes.Red }, Left = 10, Top = 10 },
            new TextItem { Text= "Lalala", Left = 50, Top = 50 },
        };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
