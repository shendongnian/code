    public bool IsUserVisible
            {
                get
                {
                    UIElement element = (UIElement)this;
                    if (!element.IsVisible)
                        return false;
                    var container = VisualTreeHelper.GetParent(element) as FrameworkElement;
                    if (container == null) throw new ArgumentNullException("container");
    
                    Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.RenderSize.Width, element.RenderSize.Height));
                    Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
                    return rect.IntersectsWith(bounds);
                }
            }
