    void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(NodeDragScrollViewer);
                double dX = (posNow.X - lastDragPoint.Value.X);
                double dY = (posNow.Y - lastDragPoint.Value.Y);
                // This was a bit of a guess, but it seems to work like a charm.
                double dMouseDragX = (posNow.X - lastDragPoint.Value.X) * (1/dScaleValue);
                double dMouseDragY = (posNow.Y - lastDragPoint.Value.Y) * (1/dScaleValue);
                lastDragPoint = posNow;
                // This situation is a drag.
                if (LbNodes.SelectedItems.Count == 0)
                {
                    NodeDragScrollViewer.ScrollToHorizontalOffset(NodeDragScrollViewer.HorizontalOffset - dX);
                    NodeDragScrollViewer.ScrollToVerticalOffset(NodeDragScrollViewer.VerticalOffset - dY);
                }
                else
                {
                    // This situation is mouse drag of items
                    foreach (ChatNodeViewModel cv in LbNodes.SelectedItems)
                    {
                        cv.XCoord += dMouseDragX;
                        cv.YCoord += dMouseDragY;
                    }
                    // This bit just causes the lines between the nodes to update.
                    Mediator.EventMediator.Instance.RefreshAllNodesDraggable();
                }
            }
        }
