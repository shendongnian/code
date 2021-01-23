            ItemsProducts = new ObservableCollection<productModel>();
                                            ItemsProducts = YourProducts           
                                            DataGridComboBoxColumn comboBoxColumn = new DataGridComboBoxColumn();
                                            comboBoxColumn.Header = row["displayname"].ToString();
                                            comboBoxColumn.SelectedValuePath = "Key";
                                            comboBoxColumn.DisplayMemberPath = "Value";
                                            Binding binding = new Binding();
                                            binding.Path = new PropertyPath(row["name"].ToString());
                                            comboBoxColumn.SelectedValueBinding = binding;
                                            Binding itemsSourceBinding = new Binding();
                                            itemsSourceBinding.Source = ItemsProducts;
                                            BindingOperations.SetBinding(comboBoxColumn, DataGridComboBoxColumn.ItemsSourceProperty, itemsSourceBinding);
                                            GridColumns.Add(comboBoxColumn);
                                        }
                                        ColumnsList.Add(row["name"].ToString()); //add the real column name
               
