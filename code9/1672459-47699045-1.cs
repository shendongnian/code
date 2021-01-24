            if (e.PropertyName == "productID")
            {
                DataGridComboBoxColumn cb = new DataGridComboBoxColumn();
                e.Column = cb;
                cb.ItemsSource = cbProductVals;
                cb.DisplayMemberPath = "Value";
                cb.SelectedValuePath = "Key";
                cb.SelectedValueBinding = new Binding("productID");
                e.Column.Header = "product price";
            }
