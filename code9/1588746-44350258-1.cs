    private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
    {
        scrollViewer.CancelDirectManipulations();
    }
    private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
    {
        scrollViewer.TryStartDirectManipulation(e.Pointer);
    }
