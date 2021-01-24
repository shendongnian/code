    private void Scroll_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        if (e.Pointer.PointerDeviceType == PointerDeviceType.Pen)
        {
            scroll.VerticalScrollMode = ScrollMode.Disabled;
            scroll.HorizontalScrollMode = ScrollMode.Disabled;
            scroll.ZoomMode = ZoomMode.Disabled;
        }
    }
