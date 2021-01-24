            if (e.PropertyName == "productID")
            {
                ComboBoxColumn cb = new ComboBoxColumn();
                e.Column = cb;
                cb.ItemsSource = cbProductVals;
                cb.DisplayMemberPath = "Value";
                cb.SelectedValuePath = "Key";
                cb.SelectedValueBinding = new Binding("productID");
                e.Column.Header = "product price";
            }
