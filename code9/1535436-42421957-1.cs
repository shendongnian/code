    public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
    {
        if (rowContainer != null)
        {
            System.Windows.Controls.Primitives.DataGridCellsPresenter presenter =
                GetChildOfType<System.Windows.Controls.Primitives.DataGridCellsPresenter>(rowContainer);
            if (presenter != null)
                return presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        }
        return null;
    }
