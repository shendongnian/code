    private void Image_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
    {
        int delta=e.GetCurrentPoint((UIElement)sender).Properties.MouseWheelDelta;
        var ct = (CompositeTransform)img.RenderTransform;
        ct.ScaleX += delta / 120;//you can set 120 to other value to change the sensitivity
        ct.ScaleY += delta / 120;
    }
