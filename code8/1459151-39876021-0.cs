     public class NameToBrushMultiValueConverter : IMultiValueConverter
     {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var dataContext = values[0];
            var dg = (DataGrid)values[1];
            var i = (DataGridCell)values[2];
            var col = i.Column.DisplayIndex;
            var row = dg.Items.IndexOf(i.DataContext);
            if (row >= 0 && col >= 0)
            {
                DataTable td1 = ((CheckXmlAppWpf.ViewModel.MainWindowViewModel)(dataContext)).GenericDataTable;
                DataTable td2 = ((CheckXmlAppWpf.ViewModel.MainWindowViewModel)(dataContext)).GenericDataTable2;
                if (!td1.Rows[row][col].Equals(td2.Rows[row][col]))
                {
                    GetCell(dg, row, col).Background = Brushes.Yellow;
                }
            }
            return SystemColors.AppWorkspaceColor;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
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
        public static DataGridRow GetRow(DataGrid dg, int index)
        {
            DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                dg.UpdateLayout();
                dg.ScrollIntoView(dg.Items[index]);
                row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }
        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            if (parent == null) return null;
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
    }
