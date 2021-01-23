    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Animation;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
            {
                var x = Canvas.GetLeft(Control1);
                var y = Canvas.GetTop(Control1);
                x = double.IsNaN(x) ? 0 : x;
                y = double.IsNaN(y) ? 0 : y;
                var point1 = new Point(x, y);
                var point2 = e.GetPosition(this);
                var animation = new PointAnimation(point1, point2, new Duration(TimeSpan.FromSeconds(1)));
                animation.EasingFunction = new CubicEase();
                Control1.BeginAnimation(UserControl1.LocationProperty, animation);
            }
        }
    }
