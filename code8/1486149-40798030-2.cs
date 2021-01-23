        //Getting column names from datatable
        string[] columnNames = (from dc in dt.Columns.Cast<DataColumn>() select dc.ColumnName).ToArray();
        
        //Add two of your columns
        dt.Columns.Add(new DataColumn("Exists", typeof(bool)));
        dt.Columns.Add(new DataColumn("Placeholder", typeof(bool)));
        
        
        //Create DataGrid Column and bind datatable fields
        foreach (string item in columnNames)
        {
                            if (item.Equals("your Normal Column"))
                            {
                                DataGridColumns.Add(new DataGridTextColumn() { Header = "Normal Column", Binding = new Binding("Normal Column Name"), Visibility = Visibility.Visible});
                            }
        
                            else if (!item.Contains("your Bool column"))
                            {
                                //Creating checkbox control 
                                
                              FrameworkElementFactory checkBox = new FrameworkElementFactory(typeof(CheckBox));
                             checkBox.SetValue(CheckBox.HorizontalAlignmentProperty, HorizontalAlignment.Center);
        
                                checkBox.Name = "Dynamic name of your check box";
                                //Creating binding
                                Binding PermissionID = new Binding(item); 
        
                                PermissionID.Mode = BindingMode.TwoWay;
                               
                                PermissionID.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                               
                               
                                checkBox.SetBinding(CheckBox.TagProperty, BindingVal);
                                
                                DataTemplate d = new DataTemplate();
                                d.VisualTree = checkBox;
                                DataGridTemplateColumn dgTemplate = new DataGridTemplateColumn();
                                dgTemplate.Header = item;
                                dgTemplate.CellTemplate = d;
                                DataGridColumns.Add(dgTemplate);
                            }
                            
                        }
    
