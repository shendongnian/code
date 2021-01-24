    public class ResizingAdorner : Adorner
        {
            // Resizing adorner uses Thumbs for visual elements.  
            // The Thumbs have built-in mouse input handling.
    
            System.Windows.Controls.Primitives.Thumb topLeft, topRight, bottomLeft, bottomRight, Left, Right, RightCenter, Center;
    
            string m_strelement_prefix = string.Empty;
            List<UIElement> multiObject = new List<UIElement>();
            List<Point> contextData = new List<Point>();
            Panel _ownerPanel;
    
            // To store and manage the adorner's visual children.
            VisualCollection visualChildren;
    
            public ResizingAdorner(UIElement adornedElement, Panel ownerPanel)
                : base(adornedElement)
            {
                _ownerPanel = ownerPanel;
                visualChildren = new VisualCollection(this);
    
                m_strelement_prefix = (adornedElement.Uid != "") ? adornedElement.Uid.Substring(0, 2) : string.Empty;
                if (m_strelement_prefix == string.Empty) { return; }
    
                switch (m_strelement_prefix)
                {
                    case "DC":
                        if (adornedElement.GetType() == typeof(Line) || adornedElement.GetType() == typeof(Ellipse))
                        {
                            BuildAdornerCorner(ref Left, Cursors.Hand);
                            BuildAdornerCorner(ref Right, Cursors.Hand);
                            Left.DragDelta += new DragDeltaEventHandler(onDragDeltaLeft);
                            Right.DragDelta += new DragDeltaEventHandler(onDragDeltaRight);
    
                            foreach (UIElement ui in _ownerPanel.Children)
                                if (ui.Uid.Contains(m_strelement_prefix)) { multiObject.Add(ui); }
                        }
                        break;
                    case "RC":
                        if (adornedElement.GetType() == typeof(Line) || adornedElement.GetType() == typeof(Ellipse))
                        {
                            BuildAdornerCorner(ref Right, Cursors.Hand);
                            Right.DragDelta += new DragDeltaEventHandler(onDragDeltaRight);
                            foreach (UIElement ui in _ownerPanel.Children)
                                if (ui.Uid.Contains(m_strelement_prefix)) { multiObject.Add(ui); }
                        }
                        break;
                    case "TC":
                        break;
    
                }
            }
    
            void onDragDeltaLeft(object sender, DragDeltaEventArgs args)
            {
                FrameworkElement adornedElement = AdornedElement as FrameworkElement;
                System.Windows.Controls.Primitives.Thumb hitThumb = sender as System.Windows.Controls.Primitives.Thumb;
                if (adornedElement == null || hitThumb == null) return;
                Point position = Mouse.GetPosition(this);
                
                double distance = 0;
                Point _startPoint = new Point();
    
                switch (m_strelement_prefix)
                {
                    #region Diameter Circle
                    case "DC":  
                    foreach (UIElement ui in multiObject)
                    {
                        if (ui.GetType() != AdornedElement.GetType())
                        {
                            switch (ui.GetType().ToString())
                            {
                                //Selected Element is Ellipse
                                case "System.Windows.Shapes.Line":
                                    _startPoint = new Point();
                                    distance = getMidPoint(new Point(((Line)ui).X2, ((Line)ui).Y2), position, out _startPoint, true);
    
                                    ((Line)ui).X2 = position.X;
                                    ((Line)ui).Y2 = position.Y;
    
                                    ((Ellipse)adornedElement).Height = ((Ellipse)adornedElement).Width = distance * 2;
                                    Canvas.SetLeft(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Left);
                                    Canvas.SetTop(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Top);
    
                                    break;
                                //Selected Element is Line
                                case "System.Windows.Shapes.Ellipse":
                                    _startPoint = new Point();
                                    distance = getMidPoint(new Point(((Line)adornedElement).X2, ((Line)adornedElement).Y2), position, out _startPoint, true);
    
                                    ((Line)adornedElement).X2 = position.X;
                                    ((Line)adornedElement).Y2 = position.Y;
    
                                    ((Ellipse)ui).Height = ((Ellipse)ui).Width = distance * 2;
                                    Canvas.SetLeft(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Left);
                                    Canvas.SetTop(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Top);
                                    break;
                            }
                        }
                    }
                    break;
                    #endregion 
                }
            }
    
            void onDragDeltaRight(object sender, DragDeltaEventArgs args)
            {
                FrameworkElement adornedElement = AdornedElement as FrameworkElement;
                System.Windows.Controls.Primitives.Thumb hitThumb = sender as System.Windows.Controls.Primitives.Thumb;
                if (adornedElement == null || hitThumb == null) return;
    
                Point position = Mouse.GetPosition(this);
                double distance = 0;
                Point _startPoint = new Point();
    
                switch (m_strelement_prefix)
                {
                    #region Diameter Circle
                    case "DC":
                        foreach (UIElement ui in multiObject)
                        {
                            if (ui.GetType() != AdornedElement.GetType())
                            {
                                switch (ui.GetType().ToString())
                                {
                                    //Selected Element is Ellipse
                                    case "System.Windows.Shapes.Line":
                                        _startPoint = new Point();
                                        distance = getMidPoint(new Point(((Line)ui).X1, ((Line)ui).Y1), position, out _startPoint, true);
    
                                        ((Line)ui).X2 = position.X;
                                        ((Line)ui).Y2 = position.Y;
    
                                        ((Ellipse)adornedElement).Height = ((Ellipse)adornedElement).Width = distance * 2;
                                        Canvas.SetLeft(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Left);
                                        Canvas.SetTop(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Top);
    
                                        break;
                                    //Selected Element is Line
                                    case "System.Windows.Shapes.Ellipse":
                                        _startPoint = new Point();
                                        distance = getMidPoint(new Point(((Line)adornedElement).X1, ((Line)adornedElement).Y1), position, out _startPoint, true);
    
                                        ((Line)adornedElement).X2 = position.X;
                                        ((Line)adornedElement).Y2 = position.Y;
    
                                        ((Ellipse)ui).Height = ((Ellipse)ui).Width = distance * 2;
                                        Canvas.SetLeft(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Left);
                                        Canvas.SetTop(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Top);
                                        break;
                                }
                            }
                        }
                        break;
                    #endregion
    
                    #region Radius Circle
                    case "RC":
                        foreach (UIElement ui in multiObject)
                        {
                            if (ui.GetType() != AdornedElement.GetType())
                            {
                                switch (ui.GetType().ToString())
                                {
                                    //Selected Element is Ellipse
                                    case "System.Windows.Shapes.Line":
                                        _startPoint = new Point();
    
                                        distance = getMidPoint(new Point(((Line)ui).X1, ((Line)ui).Y1), position, out _startPoint, false);
    
                                        ((Line)ui).X2 = position.X;
                                        ((Line)ui).Y2 = position.Y;
    
                                        ((Ellipse)adornedElement).Height = ((Ellipse)adornedElement).Width = distance * 2;
                                        Canvas.SetLeft(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Left);
                                        Canvas.SetTop(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Top);
    
                                        break;
                                    //Selected Element is Line
                                    case "System.Windows.Shapes.Ellipse":
                                        _startPoint = new Point();
                                        distance = getMidPoint(new Point(((Line)adornedElement).X1, ((Line)adornedElement).Y1), position, out _startPoint, false);
    
                                        ((Line)adornedElement).X2 = position.X;
                                        ((Line)adornedElement).Y2 = position.Y;
    
                                        ((Ellipse)ui).Height = ((Ellipse)ui).Width = distance * 2;
                                        Canvas.SetLeft(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Left);
                                        Canvas.SetTop(ui, (new Thickness((_startPoint.X - ((distance * 2) / 2)), (_startPoint.Y - ((distance * 2) / 2)), 0, 0)).Top);
                                        break;
                                }
                            }
                        }
                        break;
                    #endregion 
                }
            }
    
            private static double getMidPoint(Point _start,Point _end,out Point _middle , bool findMidPoint)
            {
                _middle = (findMidPoint) ? new Point(((_start.X + _end.X) / 2), ((_start.Y + _end.Y) / 2)) : _start;
                return getDistanceBetweenTwoPoints(_middle, _end);
            }
    
            private static double getDistanceBetweenTwoPoints(Point StartPoint, Point EndPoint)
            {
                return Math.Round(Math.Sqrt(Math.Pow((EndPoint.X - StartPoint.X), 2) + Math.Pow((EndPoint.Y - StartPoint.Y), 2)), 2);
            }
            // Arrange the Adorners.
            protected override Size ArrangeOverride(Size finalSize)
            {
    
                // desiredWidth and desiredHeight are the width and height of the element that's being adorned.  
                // These will be used to place the ResizingAdorner at the corners of the adorned element.  
                double desiredWidth = AdornedElement.DesiredSize.Width;
                double desiredHeight = AdornedElement.DesiredSize.Height;
    
                // adornerWidth & adornerHeight are used for placement as well.
                double adornerWidth = this.DesiredSize.Width;
                double adornerHeight = this.DesiredSize.Height;
    
                switch (m_strelement_prefix)
                {
                    case "DC":
                        if (AdornedElement.GetType() == typeof(Line) || AdornedElement.GetType() == typeof(Ellipse))
                        {
                            if (AdornedElement.GetType() == typeof(Ellipse)) { contextData = ((List<Point>)((AdornedElement as FrameworkElement).DataContext)); }
    
                            Line selectedLine = ((AdornedElement.GetType() == typeof(Ellipse)) && contextData.Count != 0)
                                ? new Line() { X1 = contextData[0].X, Y1 = contextData[0].Y, X2 = contextData[1].X, Y2 = contextData[1].Y }
                                : (AdornedElement as Line);
    
                            double left = Math.Min(selectedLine.X1, selectedLine.X2);
                            double top = Math.Min(selectedLine.Y1, selectedLine.Y2);
                            var startRect = new Rect(selectedLine.X1 - (Left.Width / 2), selectedLine.Y1 - (Left.Width / 2), Left.Width, Left.Height);
                            var endRect = new Rect(selectedLine.X2 - (Right.Width / 2), selectedLine.Y2 - (Right.Height / 2), Right.Width, Right.Height);
                            Left.Arrange(startRect);
                            Right.Arrange(endRect);
                        }
                        break;
                    case "RC":
                        if (AdornedElement.GetType() == typeof(Line) || AdornedElement.GetType() == typeof(Ellipse))
                        {
                            if (AdornedElement.GetType() == typeof(Ellipse)) { contextData = ((List<Point>)((AdornedElement as FrameworkElement).DataContext)); }
    
                            Line selectedLine = ((AdornedElement.GetType() == typeof(Ellipse)) && contextData.Count != 0)
                                ? new Line() { X1 = contextData[0].X, Y1 = contextData[0].Y, X2 = contextData[1].X, Y2 = contextData[1].Y }
                                : (AdornedElement as Line);
    
                            double top = Math.Min(selectedLine.Y1, selectedLine.Y2);
                            var endRect = new Rect(selectedLine.X2 - (Right.Width / 2), selectedLine.Y2 - (Right.Height / 2), Right.Width, Right.Height);
                            Right.Arrange(endRect);
                        }
                        break;
                }
                return finalSize;
            }
    
            // Helper method to instantiate the corner Thumbs, set the Cursor property, 
            // set some appearance properties, and add the elements to the visual tree.
            void BuildAdornerCorner(ref System.Windows.Controls.Primitives.Thumb cornerThumb, Cursor customizedCursor)
            {
                if (cornerThumb != null) return;
    
                cornerThumb = new System.Windows.Controls.Primitives.Thumb();
    
                // Set some arbitrary visual characteristics.
                cornerThumb.Cursor = customizedCursor;
                cornerThumb.Height = cornerThumb.Width = 10;
                cornerThumb.Background = new SolidColorBrush(Colors.Black);
    
                visualChildren.Add(cornerThumb);
            }
    
            // This method ensures that the Widths and Heights are initialized.  Sizing to content produces
            // Width and Height values of Double.NaN.  Because this Adorner explicitly resizes, the Width and Height
            // need to be set first.  It also sets the maximum size of the adorned element.
            void EnforceSize(FrameworkElement adornedElement)
            {
                if (adornedElement.Width.Equals(Double.NaN))
                    adornedElement.Width = adornedElement.DesiredSize.Width;
                if (adornedElement.Height.Equals(Double.NaN))
                    adornedElement.Height = adornedElement.DesiredSize.Height;
    
                FrameworkElement parent = adornedElement.Parent as FrameworkElement;
                if (parent != null)
                {
                    adornedElement.MaxHeight = parent.ActualHeight;
                    adornedElement.MaxWidth = parent.ActualWidth;
                }
            }
    
            // Override the VisualChildrenCount and GetVisualChild properties to interface with 
            // the adorner's visual collection.
            protected override int VisualChildrenCount { get { return visualChildren.Count; } }
            protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
    
        }    
