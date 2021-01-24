    private async void myAdaptiveGridView_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
    {
        RenderedImage.Scale(1, 1, 0, 0, 0).Start();
        var container = myAdaptiveGridView.ContainerFromIndex(myAdaptiveGridView.SelectedIndex) as FrameworkElement;
        var listViewItemPresenter = VisualTreeHelper.GetChild(container, 0) as FrameworkElement;
        var outerGrid = VisualTreeHelper.GetChild(listViewItemPresenter, 0) as FrameworkElement;
        var grid = VisualTreeHelper.GetChild(outerGrid, 0) as FrameworkElement;
        oldSetectedItem = grid;
        var TTV = grid.TransformToVisual(MainGrid);
        Point screenCoords = TTV.TransformPoint(new Point(0, 0));
        RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
        await renderTargetBitmap.RenderAsync(grid);
        RenderedImage.Source = renderTargetBitmap;
        RenderedImage.Margin = new Thickness(screenCoords.X, screenCoords.Y, 0, 0);
        RenderedImage.Width = grid.ActualWidth;
        RenderedImage.Height = grid.ActualHeight;
        RenderedImage.Visibility = Visibility.Visible;
        RenderedImage.Scale(1.5f, 1.5f, 50, 50, 500).Start();
    }
