    public void MoveTo(UserControl FoodX, double X, double Y)
    {
        Vector offset = VisualTreeHelper.GetOffset(FoodX);
        var top = offset.Y;
        TranslateTransform trans = new TranslateTransform();
        FoodX.RenderTransform = trans;
        DoubleAnimation anim1 = new DoubleAnimation(0, 200, TimeSpan.FromSeconds(2));
        trans.BeginAnimation(TranslateTransform.YProperty, anim1);
        //Added line
        trans.Changed += RecalculateCollision;
    }
    public void RecalculateCollision(object sender, EventArgs e)
    {            
        Rect r1 = BoundsRelativeTo(MovingBox, Canvas);
        Rect r2 = BoundsRelativeTo(StaticBox, Canvas);
        if (r1.IntersectsWith(r2))
        {
            MessageBox.Show("Collided");
        }
    }
    public static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
    {
        return element.TransformToVisual(relativeTo).TransformBounds(new Rect(element.RenderSize));
    }
