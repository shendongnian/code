    public static class DataGridSelectedItemsDependencyProperty
        {
            public static readonly DependencyProperty SelectedItemsChangedHandlerProperty =
                DependencyProperty.RegisterAttached("SelectedItemsChangedHandler",
                    typeof(ICommand),
                    typeof(DataGridSelectedItemsDependencyProperty),
                    new FrameworkPropertyMetadata(OnSelectedItemsChangedHandlerChanged));
    
    
            public static ICommand GetSelectedItemsChangedHandler(DependencyObject element)
            {
                if (element == null)
                    throw new ArgumentNullException(nameof(element));
    
                return element.GetValue(SelectedItemsChangedHandlerProperty) as ICommand;
            }
    
            public static void SetSelectedItemsChangedHandler(DependencyObject element, ICommand value)
            {
                if (element == null)
                    throw new ArgumentNullException(nameof(element));
    
                element.SetValue(SelectedItemsChangedHandlerProperty, value);
            }
    
            private static void OnSelectedItemsChangedHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var dataGrid = (DataGrid)d;
    
                if (e.OldValue == null && e.NewValue != null)
                    dataGrid.SelectionChanged += ItemsControl_SelectionChanged;
    
                if (e.OldValue != null && e.NewValue == null)
                    dataGrid.SelectionChanged -= ItemsControl_SelectionChanged;
            }
    
            private static void ItemsControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var dataGrid = (DataGrid)sender;
                var itemsChangedHandler = GetSelectedItemsChangedHandler(dataGrid);
                itemsChangedHandler.Execute(dataGrid.SelectedItems);
            }
        }
