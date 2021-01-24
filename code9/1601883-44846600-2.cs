    public class SizeAwareControl : Panel
    {
        private UIElement HeightDeterminingContent
        {
            get { return InternalChildren[0]; }
        }
        private UIElement WidthDeterminingContent
        {
            get { return InternalChildren[1]; }
        }
        protected override Size MeasureOverride(Size constraint)
        {
            Size result = new Size(double.PositiveInfinity, double.PositiveInfinity);
            WidthDeterminingContent.Measure(result);
            result.Width = WidthDeterminingContent.DesiredSize.Width;
            HeightDeterminingContent.Measure(result);
            result.Height = WidthDeterminingContent.DesiredSize.Height + HeightDeterminingContent.DesiredSize.Height;
            return result;
        }
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            HeightDeterminingContent.Arrange(new Rect(0, 0, WidthDeterminingContent.DesiredSize.Width, HeightDeterminingContent.DesiredSize.Height));
            WidthDeterminingContent.Arrange(new Rect(0, HeightDeterminingContent.DesiredSize.Height, WidthDeterminingContent.DesiredSize.Width, WidthDeterminingContent.DesiredSize.Height));
            return new Size(WidthDeterminingContent.DesiredSize.Width, WidthDeterminingContent.DesiredSize.Height + HeightDeterminingContent.DesiredSize.Height);
        }
    }
