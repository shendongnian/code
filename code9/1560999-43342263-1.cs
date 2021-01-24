     namespace WPFGridLoadingRow
     {
     public class DataGridExtension
        {
            public static readonly DependencyProperty RowLoadedCommandProperty = DependencyProperty.RegisterAttached(
                "RowLoadedCommand",
                typeof(ICommand),
                typeof(DataGridExtension),
                new PropertyMetadata(null, OnRowLoadedcommandChanged));
    
            private static void OnRowLoadedcommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                DataGrid dataGrid = d as DataGrid;
                if (dataGrid == null)
                    return;
    
                if (e.NewValue is ICommand)
                {
                    dataGrid.LoadingRow += DataGridOnLoadingRow;
                }
            }
    
            private static void DataGridOnLoadingRow(object sender, DataGridRowEventArgs e)
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid == null)
                    return;
    
    
                ICommand rowLoadedCommand = GetRowLoadedCommand(dataGrid);
                rowLoadedCommand.Execute(e.Row.Item);
                // you can also pass the complete row. Or you move your complete ui-logic here to this attached property.
            }
    
            public static void SetRowLoadedCommand(DependencyObject element, ICommand value)
            {
                element.SetValue(RowLoadedCommandProperty, value);
            }
    
            public static ICommand GetRowLoadedCommand(DependencyObject element)
            {
                return (ICommand)element.GetValue(RowLoadedCommandProperty);
            }
        }
    }
