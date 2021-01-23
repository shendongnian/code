    GetCell(dg, row, col).Background = Brushes.Yellow;
    public DataGridCell GetCell(DataGrid dg, int row, int column)
        {
            DataGridRow rowContainer = GetRow(dg, row);
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    dg.ScrollIntoView(rowContainer, dg.Columns[column]);
                    presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
                }
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }
    
