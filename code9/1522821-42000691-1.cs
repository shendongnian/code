    public class BorderGrid : Grid
    {
        public BorderGrid()
        {
            Background = Brushes.Transparent;
        }
        protected override void OnRender(DrawingContext dc)
        {
            double leftOffset = 0;
            double topOffset = 0;
            Pen pen = new Pen(Brushes.Gray, 0.5);
            pen.Freeze();
            foreach (RowDefinition row in RowDefinitions)
            {
                dc.DrawLine(pen, new Point(0, topOffset), new Point(this.ActualWidth, topOffset));
                topOffset += row.ActualHeight;
            }
            foreach (ColumnDefinition column in ColumnDefinitions)
            {
                dc.DrawLine(pen, new Point(leftOffset, 0), new Point(leftOffset, ActualHeight));
                leftOffset += column.ActualWidth;
            }
            base.OnRender(dc);
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            Point point = Mouse.GetPosition(this);
            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;
            foreach (var rowDefinition in RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }
            foreach (var columnDefinition in ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }
            //color cell Red:
            Grid childGrid = new Grid();
            childGrid.Background = Brushes.Red;
            Grid.SetColumn(childGrid, col);
            Grid.SetRow(childGrid, row);
            Children.Add(childGrid);
        }
