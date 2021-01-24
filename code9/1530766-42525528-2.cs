    public class ResizingAdorner : Adorner
        {
            // Resizing adorner uses Thumbs for visual elements.  
            // The Thumbs have built-in mouse input handling.
    
            System.Windows.Controls.Primitives.Thumb topLeft, topRight, bottomLeft, bottomRight, Left, Right, RightCenter, Center;
    
            // To store and manage the adorner's visual children.
            bool m_bIsSpecialObject = false;
            VisualCollection visualChildren;
    
            Panel _ownerPanel;
            public ResizingAdorner(UIElement adornedElement, Panel ownerPanel)
                : base(adornedElement)
            {
                _ownerPanel = ownerPanel;
                visualChildren = new VisualCollection(this);
    
                if (adornedElement.GetType() == typeof(Line) && adornedElement.Uid.Contains("DC"))
                {
                    BuildAdornerCorner(ref Left, Cursors.Hand);
                    BuildAdornerCorner(ref Right, Cursors.Hand);
                    Left.DragDelta += new DragDeltaEventHandler(onDragDeltaLeft);
                    Right.DragDelta += new DragDeltaEventHandler(onDragDeltaRight);
                    m_bIsSpecialObject = true;
                }
                if (adornedElement.GetType() == typeof(Ellipse) && adornedElement.Uid.Contains("DC"))
                {
                    BuildAdornerCorner(ref Left, Cursors.Hand);
                    BuildAdornerCorner(ref Right, Cursors.Hand);
                    Left.DragDelta += new DragDeltaEventHandler(onDragDeltaLeft);
                    Right.DragDelta += new DragDeltaEventHandler(onDragDeltaRight);
                    m_bIsSpecialObject = true;
                }
    
            }
    
            void onDragDeltaLeft(object sender, DragDeltaEventArgs args)
            {    
                FrameworkElement adornedElement = AdornedElement as FrameworkElement;
                System.Windows.Controls.Primitives.Thumb hitThumb = sender as System.Windows.Controls.Primitives.Thumb;
                if (adornedElement == null || hitThumb == null) return;
                Point position = Mouse.GetPosition(this);
                double left, top, distance = 0;
                Point _startPoint = new Point(), l_pMidPoint = new Point();
    
                switch (AdornedElement.GetType().ToString())
                {
                    case "System.Windows.Shapes.Line":
    
                        _startPoint = new Point(((Line)adornedElement).X2, ((Line)adornedElement).Y2);
                        l_pMidPoint = new Point(((_startPoint.X + position.X) / 2), ((_startPoint.Y + position.Y) / 2));
                        distance = getDistanceBetweenTwoPoints(l_pMidPoint, position);
    
                        foreach (UIElement ui in _ownerPanel.Children)
                        {
                            if (ui.Uid == AdornedElement.Uid && ui.GetType() != AdornedElement.GetType())
                            {
                                ((Ellipse)ui).Height = ((Ellipse)ui).Width = distance * 2;
    
                                left = l_pMidPoint.X - ((distance * 2) / 2);
                                top = l_pMidPoint.Y - ((distance * 2) / 2);
    
                                Canvas.SetLeft(ui, (new Thickness(left, top, 0, 0)).Left);
                                Canvas.SetTop(ui, (new Thickness(left, top, 0, 0)).Top);
    
                                break;
                            }
                        }
                        ((Line)adornedElement).X1 = position.X;
                        ((Line)adornedElement).Y1 = position.Y;
    
    
                        break;
                    case "System.Windows.Shapes.Ellipse":
    
                        foreach (UIElement ui in _ownerPanel.Children)
                        {
                            if (ui.Uid == AdornedElement.Uid && ui.GetType() != AdornedElement.GetType())
                            {
                                ((Line)ui).X1 = position.X;
                                ((Line)ui).Y1 = position.Y;
    
                                _startPoint = new Point(((Line)ui).X1, ((Line)ui).Y1);
                                l_pMidPoint = new Point(((_startPoint.X + position.X) / 2), ((_startPoint.Y + position.Y) / 2));
                                distance = getDistanceBetweenTwoPoints(l_pMidPoint, position);
                                break;
                            }
                        }
    
                        ((Ellipse)adornedElement).Height = ((Ellipse)adornedElement).Width = distance * 2;
                        left = l_pMidPoint.X - ((distance * 2) / 2);
                        top = l_pMidPoint.Y - ((distance * 2) / 2);
    
                        Canvas.SetLeft(adornedElement, (new Thickness(left, top, 0, 0)).Left);
                        Canvas.SetTop(adornedElement, (new Thickness(left, top, 0, 0)).Top);
    
                        break;
                }
            }
    
            void onDragDeltaRight(object sender, DragDeltaEventArgs args)
            {
                FrameworkElement adornedElement = AdornedElement as FrameworkElement;
                System.Windows.Controls.Primitives.Thumb hitThumb = sender as System.Windows.Controls.Primitives.Thumb;
                if (adornedElement == null || hitThumb == null) return;
                Point position = Mouse.GetPosition(this);
                double left, top, distance = 0;
                Point _startPoint = new Point(), l_pMidPoint = new Point();
    
                switch (AdornedElement.GetType().ToString())
                {
                    case "System.Windows.Shapes.Line":
    
                        _startPoint = new Point(((Line)adornedElement).X1, ((Line)adornedElement).Y1);
                        l_pMidPoint = new Point(((_startPoint.X + position.X) / 2), ((_startPoint.Y + position.Y) / 2));
                        distance = getDistanceBetweenTwoPoints(l_pMidPoint, position);
    
                        foreach (UIElement ui in _ownerPanel.Children)
                        {
                            if (ui.Uid == AdornedElement.Uid && ui.GetType() != AdornedElement.GetType())
                            {
                                ((Ellipse)ui).Height = ((Ellipse)ui).Width = distance * 2;
    
                                left = l_pMidPoint.X - ((distance * 2) / 2);
                                top = l_pMidPoint.Y - ((distance * 2) / 2);
    
                                Canvas.SetLeft(ui, (new Thickness(left, top, 0, 0)).Left);
                                Canvas.SetTop(ui, (new Thickness(left, top, 0, 0)).Top);
    
                                break;
                            }
                        }
                        ((Line)adornedElement).X2 = position.X;
                        ((Line)adornedElement).Y2 = position.Y;
    
    
                        break;
                    case "System.Windows.Shapes.Ellipse":
    
                        foreach (UIElement ui in _ownerPanel.Children)
                        {
                            if (ui.Uid == AdornedElement.Uid && ui.GetType() != AdornedElement.GetType())
                            {
                                ((Line)ui).X2 = position.X;
                                ((Line)ui).Y2 = position.Y;
    
                                _startPoint = new Point(((Line)ui).X1, ((Line)ui).Y1);
                                l_pMidPoint = new Point(((_startPoint.X + position.X) / 2), ((_startPoint.Y + position.Y) / 2));
                                distance = getDistanceBetweenTwoPoints(l_pMidPoint, position);
                                break;
                            }
                        }
    
                        ((Ellipse)adornedElement).Height = ((Ellipse)adornedElement).Width = distance * 2;
                        left = l_pMidPoint.X - ((distance * 2) / 2);
                        top = l_pMidPoint.Y - ((distance * 2) / 2);
                        
                        Canvas.SetLeft(adornedElement, (new Thickness(left, top, 0, 0)).Left);
                        Canvas.SetTop(adornedElement, (new Thickness(left, top, 0, 0)).Top);
    
                        break;
                }
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
    
                if (AdornedElement.GetType() == typeof(Line) && AdornedElement.Uid.Contains("DC"))
                {
                    var selectedLine = AdornedElement as Line;
                    double left = Math.Min(selectedLine.X1, selectedLine.X2);
                    double top = Math.Min(selectedLine.Y1, selectedLine.Y2);
                    var startRect = new Rect(selectedLine.X1 - (Left.Width / 2), selectedLine.Y1 - (Left.Width / 2), Left.Width, Left.Height);
                    Left.Arrange(startRect);
                    var endRect = new Rect(selectedLine.X2 - (Right.Width / 2), selectedLine.Y2 - (Right.Height / 2), Right.Width, Right.Height);
                    Right.Arrange(endRect);
                }
                else if (AdornedElement.GetType() == typeof(Ellipse) && AdornedElement.Uid.Contains("DC"))
                {
                    FrameworkElement adornedElement = AdornedElement as FrameworkElement;
                    List<Point> elipsendPoints = ((List<Point>)(adornedElement.DataContext));
                    if (elipsendPoints.Count == 0) { return finalSize; }
                    Line selectedLine = new Line() { X1 = elipsendPoints[0].X, Y1 = elipsendPoints[0].Y, X2 = elipsendPoints[1].X, Y2 = elipsendPoints[1].Y };
                    double left = Math.Min(selectedLine.X1, selectedLine.X2);
                    double top = Math.Min(selectedLine.Y1, selectedLine.Y2);
                    var startRect = new Rect(selectedLine.X1 - (Left.Width / 2), selectedLine.Y1 - (Left.Width / 2), Left.Width, Left.Height);
                    var endRect = new Rect(selectedLine.X2 - (Right.Width / 2), selectedLine.Y2 - (Right.Height / 2), Right.Width, Right.Height);
                    Left.Arrange(startRect);
                    Right.Arrange(endRect);
                }
                // Return the final size.
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
