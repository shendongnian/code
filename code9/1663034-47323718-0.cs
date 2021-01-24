    private List<InkStroke> undoList = new List<InkStroke>();
    private void Undo(object sender, RoutedEventArgs e)
    {
        IReadOnlyList<InkStroke> inkList = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
        if (inkList.Count > 0)
        {
            InkStroke undoStroke = inkList[inkList.Count - 1];
            undoStroke.Selected = true;
            undoList.Add(undoStroke.Clone());
            inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
        }
    }
    private void Redo(object sender, RoutedEventArgs e)
    {
        if (undoList.Count > 0)
        {
            InkStroke redoStroke = undoList[undoList.Count - 1];
            inkCanvas.InkPresenter.StrokeContainer.AddStroke(redoStroke);
            undoList.Remove(redoStroke);
        }
    }
