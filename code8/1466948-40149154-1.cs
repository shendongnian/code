    namespace Blink
    {
        using System;
        using System.Collections.Generic;
        using System.Windows;
        using System.Windows.Media;
        using System.Windows.Media.Animation;
        using System.Windows.Shapes;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public Random random = new Random();
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public List<Ellipse> CreateCircles(int count)
            {
                List<Ellipse> circles = new List<Ellipse>();
                for (int i = 0; i < count; i++)
                {
                    var circle = new Ellipse
                    {
                        Height = 100,
                        Width = 100,
                        Margin = new Thickness(10),
                        Fill = Brushes.SkyBlue
                    };
    
                    circles.Add(circle);
                }
    
                return circles;
            }
    
            public void AddCircles()
            {
                var circles = this.CreateCircles(8);
                foreach (var circle in circles)
                {
                    Container.Children.Add(circle);
                }
            }
    
            private void Container_Loaded(object sender, RoutedEventArgs e)
            {
                AddCircles();
            }
    
            private void BlinkEm_Click(object sender, RoutedEventArgs e)
            {
                foreach (Ellipse circle in Container.Children)
                {
                    circle.Fill = GetRandomColor();
                    circle.BeginAnimation(Ellipse.OpacityProperty, GetBlinkAnimation());
                }
            }
    
            public Brush GetRandomColor()
            {
                var red = Convert.ToByte(random.Next(0, 255));
                var green = Convert.ToByte(random.Next(0, 255));
                var blue = Convert.ToByte(random.Next(0, 255));
    
                return new SolidColorBrush(Color.FromRgb(red, green, blue));
            }
    
            public DoubleAnimation GetBlinkAnimation()
            {
                var duration = random.NextDouble();
                var animation = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = new Duration(TimeSpan.FromSeconds(duration)),
                    RepeatBehavior = RepeatBehavior.Forever
                };
    
                return animation;
            }
        }
    }
