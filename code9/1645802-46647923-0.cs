    protected override Size ArrangeOverride(Size finalSize) {
      foreach (var child in Children) {
        var resizable = child as IArrangeable;
        resizable?.Arrange(pointDictionary.GetValueOrDefault(resizable.Card));
      }
      return finalSize;
    }
    private double GetMaxOffset {
      get { return columnOffsetY.Max(); }
    }
    
    protected override Size MeasureOverride(Size availableSize) {
      var desiredSize = availableSize;
      UpdateColumnOffsets();
      foreach (var child in Children) {
        child.Measure(desiredSize);
        CreateOffsetCache(child);
      }
      if (Double.IsPositiveInfinity(desiredSize.Height))
        desiredSize.Height = GetMaxOffset;
      
      return desiredSize;
      
    }
    private Dictionary<Card, Point> pointDictionary;
    private void CreateOffsetCache(UIElement child) {
      var arrangeable = child as IArrangeable;
      if (arrangeable == null) return;
      var card = arrangeable.Card;
      var useColumnOffset = columnOffsetY[card.Column] < columnOffsetY[card.Column + card.ColumnSpan - 1] 
        ? columnOffsetY[card.Column + card.ColumnSpan - 1] : columnOffsetY[card.Column];
      var point = new Point(columnOffsetX[card.Column], useColumnOffset);
      pointDictionary[card] = point;
      SetColumnOffsetY(card.Column, card.ColumnSpan, child.DesiredSize.Height);
    }
