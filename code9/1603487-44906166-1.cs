    void GetPointerPosition()
    {
        mainGrid.PointerMoved += mainGrid_PointerMoved;
    }
    void MainStack_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        mainGrid.PointerMoved -= mainGrid_PointerMoved;
        var x = e.GetCurrentPoint(mainGrid).Position.X;
        var y = e.GetCurrentPoint(mainGrid).Position.Y;
    }
