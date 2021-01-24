    private void DisableEditing(Grid theGrid)
    {
        // Remove all Adorners of all Controls
        foreach (FrameworkElement child in theGrid.Children)
        {
            var layer = AdornerLayer.GetAdornerLayer(child);
            var adorners = layer.GetAdorners(child);
            if (adorners == null)
                continue;
            foreach(var adorner in adorners)
                layer.Remove(adorner);
        }
    }
    private void EnableEditing(Grid theGrid)
    {
        foreach (FrameworkElement child in theGrid.Children)
        {
            // Add a MoveAdorner for every single child
            Adorner adorner = new MoveAdorner(child);
            // Add the Adorner to the closest (hierarchically speaking) AdornerLayer
            AdornerLayer.GetAdornerLayer(child).Add(adorner);
        }
    }
