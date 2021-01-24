    private Rectangle rect;
    void ...()
    {
        rect = new Rectangle();
        Grid.SetRow(rect, rowNum);
        Grid.SetColumn(rect, colNum);
        Grid.SetColumnSpan(rect, dataGrd_.ColumnDefinitions.Count);
        rect.Fill = new SolidColorBrush(Colors.White);
        rect.MouseEnter += Rect_MouseEnter;
        rect.MouseLeave += Rect_MouseLeave;
        dataGrd_.Children.Add(rect);
        dataGrd_.MouseEnter += dataGrd__MouseEnter;
        dataGrd_.MouseLeave += dataGrd__MouseLeave;
    }
