    public sealed partial class MyUserControl1 : UserControl
    {
        public MyUserControl1()
        {
            this.InitializeComponent();
        }
        public double Horizontalofset
        {
            get { return (double)GetValue(HorizontalofsetProperty); }
            set { SetValue(HorizontalofsetProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Horizontalofset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalofsetProperty =
            DependencyProperty.Register("Horizontalofset", typeof(double), typeof(MyUserControl1), new PropertyMetadata(0,PropertyChangedCallback));
        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var distance = (d as MyUserControl1).scrolviewer.ScrollableWidth;
            if (distance > (double)e.NewValue)
            {
                var ret = (d as MyUserControl1).scrolviewer.ChangeView((double)e.NewValue, (d as MyUserControl1).scrolviewer.VerticalOffset, (d as MyUserControl1).scrolviewer.ZoomFactor);
                Debug.WriteLine(ret);
            }
            
        }
    }
