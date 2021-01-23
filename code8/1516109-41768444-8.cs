    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        public partial class UserControl1
        {
            public static readonly DependencyProperty LocationProperty = DependencyProperty.Register(
                "Location", typeof(Point), typeof(UserControl1), new PropertyMetadata(default(Point), OnLocationChanged));
    
            public UserControl1()
            {
                InitializeComponent();
    
                DependencyPropertyDescriptor.FromProperty(Canvas.LeftProperty, typeof(Canvas))
                    .AddValueChanged(this, OnLeftChanged);
                DependencyPropertyDescriptor.FromProperty(Canvas.TopProperty, typeof(Canvas))
                    .AddValueChanged(this, OnTopChanged);
            }
    
            public Point Location
            {
                get { return (Point) GetValue(LocationProperty); }
                set { SetValue(LocationProperty, value); }
            }
    
            private void OnLeftChanged(object sender, EventArgs eventArgs)
            {
                var left = Canvas.GetLeft(this);
                Location = new Point(left, Location.Y);
            }
    
            private void OnTopChanged(object sender, EventArgs e)
            {
                var top = Canvas.GetTop(this);
                Location = new Point(Location.X, top);
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
