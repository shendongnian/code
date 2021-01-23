       public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child is T)
                        return (T)child;
                    else
                    {
                        T childOfChild = FindVisualChild<T>(child);
                        if (childOfChild != null)
                            return childOfChild;
                    }
                }
                return null;
            }
            public static System.Windows.Controls.DataGridCell GetCell(System.Windows.Controls.DataGrid dataGrid, DataGridRow rowContainer, int column)
            {
                if (rowContainer != null)
                {
                    DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                    if (presenter == null)
                    {
                        /* if the row has been virtualized away, call its ApplyTemplate() method
                         * to build its visual tree in order for the DataGridCellsPresenter
                         * and the DataGridCells to be created */
                        rowContainer.ApplyTemplate();
                        presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                    }
                    if (presenter != null)
                    {
                        System.Windows.Controls.DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as System.Windows.Controls.DataGridCell;
                        if (cell == null)
                        {
                            /* bring the column into view
                             * in case it has been virtualized away */
                            dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                            cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as System.Windows.Controls.DataGridCell;
                        }
                        return cell;
                    }
                }
                return null;
            }
            public static void SelectCellByIndex(System.Windows.Controls.DataGrid dataGrid, int rowIndex, int columnIndex)
            {
                if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.Cell))
                    throw new ArgumentException("The SelectionUnit of the DataGrid must be set to Cell.");
    
                if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));
    
                if (columnIndex < 0 || columnIndex > (dataGrid.Columns.Count - 1))
                    throw new ArgumentException(string.Format("{0} is an invalid column index.", columnIndex));
    
                dataGrid.SelectedCells.Clear();
    
                object item = dataGrid.Items[rowIndex]; //=Product X
                DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                if (row == null)
                {
                    dataGrid.ScrollIntoView(item);
                    row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                }
                if (row != null)
                {
                    System.Windows.Controls.DataGridCell cell = GetCell(dataGrid, row, columnIndex);
                    if (cell != null)
                    {
                        DataGridCellInfo dataGridCellInfo = new DataGridCellInfo(cell);
                        dataGrid.SelectedCells.Add(dataGridCellInfo);
                        cell.Focus();
                    }
                }
            }
