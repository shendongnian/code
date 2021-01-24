    private void objectManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        var stackDragged = e.OriginalSource as StackPanel;
        (stackDragged.RenderTransform as TranslateTransform).X += e.Delta.Translation.X;
        (stackDragged.RenderTransform as TranslateTransform).Y += e.Delta.Translation.Y;
    }
