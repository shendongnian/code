     public UIElement GetAtMousePos()
        {
            UIElement element;
            Point p = Mouse.GetPosition(Canvas as UIElement);
            HitTestResult result = VisualTreeHelper.HitTest(Canvas, p);
            if (result != null)
            {
                element = result.VisualHit as UIElement;
                return element;
            }
            else
            {
                return null;
            }
        }
