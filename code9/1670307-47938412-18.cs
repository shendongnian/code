    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    public class MoveAdorner : Adorner
    {
        // The parent of the adorned Control, in your case a Grid
        private readonly Panel _parent;
        // Same as "AdornedControl" but as a FrameworkElement
        private readonly FrameworkElement _child;
        // The visual overlay rectangle we can click and drag
        private readonly Rectangle _rect;
        // Our own collection of child elements, in this example only _rect
        private readonly UIElementCollection _visualChildren;
        private bool _down;
        private Point _downPos;
        private Thickness _downMargin;
        
        private List<Rect> _otherRects;
        protected override int VisualChildrenCount => _visualChildren.Count;
        protected override Visual GetVisualChild(int index)
        {
            return _visualChildren[index];
        }
        public MoveAdorner(FrameworkElement adornedElement) : base(adornedElement)
        {
            _child = adornedElement;
            _parent = adornedElement.Parent as Panel;
            _visualChildren = new UIElementCollection(this,this);
            _rect = new Rectangle
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                StrokeThickness = 1,
            };
            SetColor(Colors.LightGray);
            _rect.MouseLeftButtonDown += RectOnMouseLeftButtonDown;
            _rect.MouseLeftButtonUp += RectOnMouseLeftButtonUp;
            _rect.MouseMove += RectOnMouseMove;
            _visualChildren.Add(_rect);
        }
        private void SetColor(Color color)
        {
            _rect.Fill = new SolidColorBrush(color) {Opacity = 0.3};
            _rect.Stroke = new SolidColorBrush(color) {Opacity = 0.5};
        }
        private void RectOnMouseMove(object sender, MouseEventArgs args)
        {
            if (!_down) return;
            Point pos = args.GetPosition(_parent);
            UpdateMargin(pos);
        }
        private void UpdateMargin(Point pos)
        {
            double deltaX = pos.X - _downPos.X;
            double deltaY = pos.Y - _downPos.Y;
            Thickness newThickness = new Thickness(_downMargin.Left + deltaX, _downMargin.Top + deltaY, 0, 0);
            //Restrict to parent's bounds
            double leftMax = _parent.ActualWidth - _child.ActualWidth;
            double topMax = _parent.ActualHeight - _child.ActualHeight;
            newThickness.Left = Math.Max(0, Math.Min(newThickness.Left, leftMax));
            newThickness.Top = Math.Max(0, Math.Min(newThickness.Top, topMax));
            _child.Margin = newThickness;
            bool overlaps = CheckForOverlap();
            SetColor(overlaps ? Colors.Red : Colors.Green);
        }
        // Check the current position for overlaps with all other controls
        private bool CheckForOverlap()
        {
            if (_otherRects == null || _otherRects.Count == 0)
                return false;
            Rect thisRect = GetRect(_child);
            foreach(Rect otherRect in _otherRects)
                if (thisRect.IntersectsWith(otherRect))
                    return true;
            return false;
        }
        private Rect GetRect(FrameworkElement element)
        {
            return new Rect(new Point(element.Margin.Left, element.Margin.Top), new Size(element.ActualWidth, element.ActualHeight));
        }
        private void RectOnMouseLeftButtonUp(object sender, MouseButtonEventArgs args)
        {
            if (!_down) return;
            Point pos = args.GetPosition(_parent);
            UpdateMargin(pos);
            if (CheckForOverlap())
                ResetMargin();
            _down = false;
            _rect.ReleaseMouseCapture();
            SetColor(Colors.LightGray);
        }
        private void ResetMargin()
        {
            _child.Margin = _downMargin;
        }
        private void RectOnMouseLeftButtonDown(object sender, MouseButtonEventArgs args)
        {
            _down = true;
            _rect.CaptureMouse();
            _downPos = args.GetPosition(_parent);
            _downMargin = _child.Margin;
            // The current position of all other elements doesn't have to be updated
            // while we move this one so we only determine it once
            _otherRects = new List<Rect>();
            foreach (FrameworkElement child in _parent.Children)
            {
                if (ReferenceEquals(child, _child))
                    continue;
                _otherRects.Add(GetRect(child));
            }
        }
        // Whenever the adorned control is resized or moved
        // Update the size of the overlay rectangle
        // (Not 100% necessary as long as you only move it)
        protected override Size MeasureOverride(Size constraint)
        {
            _rect.Measure(constraint);
            return base.MeasureOverride(constraint);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            _rect.Arrange(new Rect(new Point(0,0), finalSize));
            return base.ArrangeOverride(finalSize);
        }
    }
