    FrameworkElement lastPopUpElement = null;
    private void GridView_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        lastPopUpElement = VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(sender as FrameworkElement) as FrameworkElement) as FrameworkElement;
        Canvas.SetZIndex(lastPopUpElement, 1);
        lastPopUpElement.Scale(scaleX: 1.5f, scaleY: 1.5f, centerX: 50, centerY: 50, easingType: EasingType.Sine).Start();
    }
    private void GridView_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        if (lastPopUpElement != null)
        {
            Canvas.SetZIndex(lastPopUpElement, 0);
            lastPopUpElement.Scale(centerX: 50, centerY: 50, easingType: EasingType.Sine).Start();
        }
    }
