    public class SimpleCircleAdorner : Adorner
    {
        // Be sure to call the base class constructor.
        public SimpleCircleAdorner(UIElement adornedElement, Panel ownerPanel)
          : base(adornedElement)
        {
            _ownerPanel = ownerPanel; 
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            Point point = Mouse.GetPosition(AdornedElement);
            _currentPosition = getMousePosition(point);
            switch (_currentPosition)
            {
                case MousePosition.BR:
                case MousePosition.TL:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case MousePosition.BL:
                case MousePosition.TR:
                    Cursor = Cursors.SizeNESW;
                    break;
            }
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        { 
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(AdornedElement);
            if (adornerLayer != null)
            {
                Adorner[] adorners = adornerLayer.GetAdorners(AdornedElement);
                if (adorners != null)
                {
                    foreach (Adorner adorner in adorners)
                    { 
                        adornerLayer.Remove(adorner);
                    }
                }
            }
        }
        MousePosition _currentPosition;
        Panel _ownerPanel;
        bool _isDraging = false;
        Point _startPosition;
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (Mouse.Capture(this))
            {
                _isDraging = true;
                _startPosition = Mouse.GetPosition(_ownerPanel);
            }
        }
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if (_isDraging)
            {
                Point newPosition = Mouse.GetPosition(_ownerPanel);
                double diffX = (newPosition.X - _startPosition.X);
                double diffY = (newPosition.Y - _startPosition.Y);
                // we should decide whether to change Width and Height or to change Canvas.Left and Canvas.Right
                if (Math.Abs(diffX) >= 1 || Math.Abs(diffY) >= 1)
                { 
                    switch (_currentPosition)
                    {
                        case MousePosition.TL:
                        case MousePosition.BL:
                            foreach (FrameworkElement ui in _ownerPanel.Children)
                            { 
                                Canvas.SetLeft(ui, Math.Max(0, Canvas.GetLeft(ui) + diffX)); 
                                ui.Width = Math.Max(0, ui.Width - diffX);
                            }
                            _ownerPanel.InvalidateArrange();
                            
                            break;
                        case MousePosition.BR:
                        case MousePosition.TR:
                            foreach (FrameworkElement ui in _ownerPanel.Children)
                                ui.Width = Math.Max(0, ui.Width + diffX);
                            break;
                    }
                 
                
                    switch (_currentPosition)
                    {
                        case MousePosition.TL:
                        case MousePosition.TR:
                            foreach (FrameworkElement ui in _ownerPanel.Children)
                                Canvas.SetTop(ui, Math.Max(0, Canvas.GetTop(ui) + diffY));
                            foreach (FrameworkElement ui in _ownerPanel.Children)
                                ui.Height = Math.Max(0, ui.Height - diffY);
                            break;
                        case MousePosition.BL:
                        case MousePosition.BR: 
                            foreach (FrameworkElement ui in _ownerPanel.Children)
                                ui.Height = Math.Max(0, ui.Height + diffY);
                            break;
                    }
                }
                _startPosition = newPosition;
            }
        }
        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (_isDraging)
            {
                Mouse.Capture(null);
                _isDraging = false;
            }
        }
        MousePosition getMousePosition(Point point) // point relative to element
        {
            double h2 = ActualHeight / 2;
            double w2 = ActualWidth / 2;
            if (point.X < w2 && point.Y < h2)
                return MousePosition.TL;
            else if (point.X > w2 && point.Y > h2)
                return MousePosition.BR;
            else if (point.X > w2 && point.Y < h2)
                return MousePosition.TR;
            else
                return MousePosition.BL;
        }
        enum MousePosition
        {
            TL,
            TR,
            BL,
            BR
        }
        double _renderRadius = 5.0;
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize); 
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
            renderBrush.Opacity = 0.3;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Black), 1.5); 
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, _renderRadius, _renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, _renderRadius, _renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, _renderRadius, _renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, _renderRadius, _renderRadius);
        }
    }
