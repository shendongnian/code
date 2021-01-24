            var itemsSource = MESearchDatagrid.ItemsSource;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    var row = MESearchDatagrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        var data = row.Item as UserClass;
                        MessageBox.Show(data.Name);
                    }
                }
            }
