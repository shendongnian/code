    public class DynamicGrid : Grid
    {
        public static readonly DependencyProperty AdjustColumnWidthProperty =
            DependencyProperty.RegisterAttached("AdjustColumnWidth",
                typeof(double),
                typeof(DynamicGrid),
                new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsArrange));
        public static double GetAdjustColumnWidth(DependencyObject d)
        {
            return (double)d.GetValue(AdjustColumnWidthProperty);
        }
        public static void SetAdjustColumnWidth(DependencyObject d, double value)
        {
            d.SetValue(AdjustColumnWidthProperty, value);
        }
        private int getSquareLength(int items)
        {
            double result = Math.Sqrt(items);
            return (int)Math.Ceiling(result);
        }
        private int getColumns(int length)
        {
            return length;
        }
        private int getRows(int length)
        {
            var count = _currentChildrenCount;
            //assume we can have empty row
            var rows = length - 1;
            //if fits the bill - great!
            if (rows * length >= count)
                return rows;
            else
                return rows + 1;
        }
        private int _currentChildrenCount;
        private void OnNumberOfItemsChangedImpl()
        {
            var numOfChildren = _currentChildrenCount;
            using (var d = Dispatcher.DisableProcessing())
            {
                RowDefinitions.Clear();
                ColumnDefinitions.Clear();
                if (numOfChildren > 0)
                {
                    var squareLength = getSquareLength(numOfChildren);
                    var numOfCols = getColumns(squareLength);
                    var numOfRows = getRows(squareLength);
                    for (var i = 0; i < numOfRows; i++)
                        RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    for (var i = 0; i < numOfCols; i++)
                        ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    var adjustWidthFactor = 1.0;
                    var adjustWidthOnLastRow = numOfChildren < (numOfCols * numOfRows);
                    if (adjustWidthOnLastRow)
                    {
                        var notEmptySlots = (numOfChildren % numOfCols);
                        adjustWidthFactor = ((double)numOfCols / (double)notEmptySlots);
                    }
                    int row = 0, col = 0;
                    foreach (var view in Children)
                    {
                        var cell = (FrameworkElement)view;
                        SetRow(cell, row);
                        SetColumn(cell, col);
                        if (adjustWidthOnLastRow && row == (numOfRows - 1))
                            SetAdjustColumnWidth(cell, adjustWidthFactor);
                        else
                            SetAdjustColumnWidth(cell, 1.0);
                        if (++col >= numOfCols)
                        {
                            col = 0;
                            row++;
                        }
                    }
                }
            }
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var toReturn = base.ArrangeOverride(arrangeSize);
            foreach (var view in Children)
            {
                var cell = (FrameworkElement)view;
                var adjustWidthFactor = GetAdjustColumnWidth(cell);
                var bounds = LayoutInformation.GetLayoutSlot(cell);
                var newBounds = new Rect(
                        x: bounds.Width * adjustWidthFactor * GetColumn(cell),
                        y: bounds.Top,
                        width: bounds.Width * adjustWidthFactor,
                        height: bounds.Height
                    );
                cell.Arrange(newBounds);
            }
            return toReturn;
        }
        public DynamicGrid()
        {
            _currentChildrenCount = 0;
            LayoutUpdated += (s, e) => {
                if (Children?.Count != _currentChildrenCount)
                {
                    _currentChildrenCount = (Children != null) ? Children.Count : 0;
                    OnNumberOfItemsChangedImpl();
                }
            };
        }
    }
