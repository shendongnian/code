    public class ZeroWidthDecorator : Border
    {
        private Size _lastSize;
        private Size _idealSize;
        protected override void OnVisualChildrenChanged(DependencyObject added, DependencyObject removed)
        {
            base.OnVisualChildrenChanged(added, removed);
            _idealSize = new Size();
            _lastSize = new Size();
        }
        protected override Size MeasureOverride(Size constraint)
        {
            var child = this.Child;
            if (child == null)
                return new Size();
            if (child.IsMeasureValid)
                child.Measure(new Size(_lastSize.Width, Math.Max(_lastSize.Height, constraint.Height)));
            else
                child.Measure(new Size(0d, constraint.Height));
            _idealSize = child.DesiredSize;
            return new Size(0d, _idealSize.Height);
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var child = this.Child;
            if (child != null)
            {
                if (arrangeSize != _lastSize)
                {
                    // Our parent will assume our measure is the same if the last
                    // arrange bounds are still available, so force a reevaluation.
                    this.InvalidateMeasure();
                }
                child.Arrange(new Rect(arrangeSize));
            }
            _lastSize = arrangeSize;
            return arrangeSize;
        }
    }
