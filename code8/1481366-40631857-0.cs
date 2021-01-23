    public class MyDataGrid : DataGrid
    {
        private void ValidateColumnVisibility()
        {
            if (Items.Count == 0 || Items[0] == CollectionView.NewItemPlaceholder) return;
            var itemClass = Items[0].GetType();
            foreach (var column in Columns)
            {
                if (column.GetType() == typeof(DataGridTextColumn))
                {
                    // find the property that this column is bound to
                    DataGridBoundColumn boundColumn = column as DataGridBoundColumn;
                    Binding binding = boundColumn.Binding as Binding;
                    string boundPropertyName = binding.Path.Path;
                    var prop = itemClass.GetProperty(boundPropertyName);
                    // Validating Column.Visibility when first value is null
                    // when all values are null -> Visibility.Collapsed
                    // bound value not a string -> Visibility.Visible
                    // all bound strings empty  -> Visibility.Collapsed
                    if (prop.GetValue(Items[0]) == null)
                    {
                        column.Visibility = Visibility.Collapsed;
                        foreach (var item in Items)
                        {
                            if (item != CollectionView.NewItemPlaceholder)
                            {
                                if (prop.GetValue(item) != null)
                                {
                                    if (prop.GetValue(item).GetType() != typeof(String))
                                        column.Visibility = Visibility.Visible;
                                    else if (String.IsNullOrEmpty(prop.GetValue(item) as String) == false)
                                        column.Visibility = Visibility.Visible;
                                }
                            }
                        }
                    }
                    // First value not null and all bound strings empty -> Visibility.Collapsed
                    else if (prop.GetValue(Items[0]).GetType() == typeof(String))
                    {
                        column.Visibility = Visibility.Collapsed;
                        foreach (var item in Items)
                        {
                            if (item != CollectionView.NewItemPlaceholder)
                            {
                                if (String.IsNullOrEmpty(prop.GetValue(item) as String) == false)
                                    column.Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }
        }
        protected override void OnItemsSourceChanged(
            IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            ValidateColumnVisibility();
        }
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            ValidateColumnVisibility();
        }
    }
