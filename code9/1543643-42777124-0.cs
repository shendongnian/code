    public class MyContentControl : ContentControl
    {
        public MyContentControl()
        {
            this.SizeChanged += MyContentControl_SizeChanged;
        }
        private void MyContentControl_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SizeChanged: height " + e.NewSize.Height + " width: " + e.NewSize.Width);
            CHeight = e.NewSize.Height;
        }
        public double CHeight
        {
            get { return (double)GetValue(CHeightProperty); }
            set { SetValue(CHeightProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CHeightProperty =
            DependencyProperty.Register("CHeight", typeof(double), typeof(MyContentControl), new PropertyMetadata(0));
    }
