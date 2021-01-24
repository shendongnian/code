    public static void Slide(this UIElement target, Orientation orientation, double? from, double to, int duration = 400, int startTime = 0, EasingFunctionBase easing = null)
    {
        if (easing == null)
        {
            easing = new ExponentialEase();
        }
    
        var transform = new CompositeTransform();
        target.RenderTransform = transform;
        target.RenderTransformOrigin = new Point(0.5, 0.5);
    
        var db = new DoubleAnimation
        {
            To = to,
            From = from,
            EasingFunction = easing,
            Duration = TimeSpan.FromMilliseconds(duration)
        };
        Storyboard.SetTarget(db, target);
        var axis = orientation == Orientation.Horizontal ? "X" : "Y";
        Storyboard.SetTargetProperty(db, $"(UIElement.RenderTransform).(CompositeTransform.Translate{axis})");
    
        var sb = new Storyboard
        {
            BeginTime = TimeSpan.FromMilliseconds(startTime)
        };
    
        sb.Children.Add(db);
        sb.Begin();
    }
