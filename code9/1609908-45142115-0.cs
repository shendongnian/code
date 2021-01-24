    <Window x:Class="WpfApplication.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="1080" Width="1024">
        <Canvas Name="MainCanvas" MouseDown="MainCanvas_MouseDown" Background="Red">
        
        </Canvas>
    </Window>
    public partial class MainWindow : Window
    {
        double privi = 0.1;
        Rectangle rect;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10000; i++)
            {
                Line l = new Line();
                l.Stroke = Brushes.Black;
                l.StrokeThickness = 1;
                l.X1 = 50 + privi;
                l.Y1 = 50 + privi;
                l.X2 = 100;
                l.Y2 = 100 + privi;
                MainCanvas.Children.Add(l);
                privi += 5;
            }
            rect = new Rectangle();
            rect.Width = 200;
            rect.Height = 200;
            rect.Margin = new Thickness(5, 5, 5, 5);
            rect.Stroke = Brushes.Black;
            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);
            MainCanvas.Children.Add(rect);
        }
        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (clicked)
            {
                Point p = Mouse.GetPosition(MainCanvas);
                rect.Margin = new Thickness(p.X - 25, p.Y - 25, 0, 0);
            }
        }
    }
