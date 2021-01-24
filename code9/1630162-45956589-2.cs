    public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int columnIndex)
    {
        if (row != null)
        {
            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
            if (presenter == null)
            {
                grid.ScrollIntoView(row, grid.Columns[columnIndex]);
                presenter = GetVisualChild<DataGridCellsPresenter>(row);
            }
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            return cell;
        }
        return null;
    }
