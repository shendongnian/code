        private void AppClickCommandExecuted(IList<DataGridCellInfo> cells)
        {
            if(cells != null && cells.Count > 0)
            {
                DataGridCellInfo cellInfo = cells[0];
                FrameworkElement cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
                if (cellContent != null)
                {
                    DataGridCell cell = cellContent.Parent as DataGridCell;
                    if(cell != null)
                    {
                        Point screenCoordinates = cell.PointToScreen(new Point(0, 0));
                        //place your popup based on the screen coordinates of the cell...
                    }
                }
            }
        }
