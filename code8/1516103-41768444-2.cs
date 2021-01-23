    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        public partial class UserControl1
        {
            public static readonly DependencyProperty LocationProperty = DependencyProperty.Register(
                "Location", typeof(Point), typeof(UserControl1), new UIPropertyMetadata(default(Point), OnLocationChanged));
    
            public UserControl1()
            {
                InitializeComponent();
            }
    
            public Point Location
            {
                get { return (Point) GetValue(LocationProperty); }
                set { SetValue(LocationProperty, value); }
            }
    
            private static void OnLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var control1 = (UserControl1) d;
                var value = (Point) e.NewValue;
                Canvas.SetLeft(control1, value.X);
                Canvas.SetTop(control1, value.Y);
            }
        }
    }
