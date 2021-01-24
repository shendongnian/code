    public class MyPanel : StackPanel
    {
        static MyPanel()
        {
            OrientationProperty.OverrideMetadata(typeof(MyPanel), new FrameworkPropertyMetadata(Orientation.Horizontal));
        }
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            if (Children.Count >= 2)
            {
                var child = Children[0] as FrameworkElement;
                if (child != null)
                    dc.DrawLine(new Pen(Brushes.Red, 2), new Point(child.ActualWidth + 2, 5), new Point(child.ActualWidth + 2, ActualHeight - 5));
            }
        }
    }
