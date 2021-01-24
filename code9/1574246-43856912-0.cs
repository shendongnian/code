    public class ExtendedDataGrid : DataGrid
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            //This provides the DataGrid with a customized version for DataGridRow
            return new ExtendedDataGridRow();
        }
    }
    public class ExtendedDataGridRow : DataGridRow {  }
    public class ExtendedDataGridCellsPresenter : System.Windows.Controls.Primitives.DataGridCellsPresenter
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            //This provides the DataGrid with a customized version for DataGridCell
            return new ExtendedDataGridCell();
        }
    }
    public class ExtendedDataGridCell : DataGridCell
    {
        // Your custom/overridden implementation can be added here
    }
