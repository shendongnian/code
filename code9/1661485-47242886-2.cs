    // this is in namespace WpfApplication1
    partial class Resources : ResourceDictionary {
        public Resources() {
            InitializeComponent();
        }
        private void OnMyButtonMouseLeave(object sender, MouseEventArgs e) {
            var btn = (Button) sender;
            var gradient = btn.Background as RadialGradientBrush;
            if (gradient == null)
                return;
            gradient.GradientOrigin = new Point(0.5, 0.5); // Default
            gradient.Center = gradient.GradientOrigin;
        }
        private void OnMyButtonMouseMove(object sender, MouseEventArgs e) {
            var btn = (Button) sender;
            var gradient = btn.Background as RadialGradientBrush;
            if (gradient == null)
                return;
            Point pt = Mouse.GetPosition(btn);
            gradient.GradientOrigin = new Point(pt.X / btn.ActualWidth, pt.Y / btn.ActualHeight);
            gradient.Center = gradient.GradientOrigin;
        }
    }
