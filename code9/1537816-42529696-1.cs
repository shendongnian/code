     private void dataGrid_Sorting(object sender, DataGridSortingEventArgs e)
            {
                string sortMemberPath = e.Column.SortMemberPath;
                if (sortMemberPath == null || sortMemberPath == "")
                {
                    return;
                }
                IValueConverter converter = null;
                switch (sortMemberPath)
                {
                    case "mySortMemberPath":
                        converter = new myConverter();
                        break;
                }
                if (converter != null)
                {
                    e.Handled = true;
                    ListSortDirection direction = (e.Column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
                    if (direction == ListSortDirection.Ascending)
                    {
                        dataGrid.ItemsSource = --sort my list with converter--
                    }
                    else
                    {
                        dataGrid.ItemsSource = --sort my list with converter--
                    }
                    datagridView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
                    e.Column.SortDirection = direction;
                    applyCollectionViewFilter();
                }
            }
