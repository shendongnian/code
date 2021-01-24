    private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        string headername = e.Column.Header.ToString();
        //// Any column not in header details is a hidden column
        if (this.headerDetails.ContainsKey(headername))
        {
            Style centerStyle = new Style { TargetType = typeof(DataGridCell) };
            centerStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center));
            Style headerCenterStyle = new Style { TargetType = typeof(DataGridColumnHeader) };
            headerCenterStyle.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            try
            {
                e.Column.Width = Double.Parse(this.headerDetails[headername].Width);
            }
            catch(Exception ex)
            {
                    e.Column.Width = 100;
            }
    
            // You can also add bindings here if required
            Binding headerTextBinding = new Binding();
            headerTextBinding.Source = this.headerDetails[headername];
            headerTextBinding.Path = new PropertyPath("Header");
            headerTextBinding.Mode = BindingMode.TwoWay;
            headerTextBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(e.Column, DataGridTextColumn.HeaderProperty, headerTextBinding);
            e.Column.HeaderStyle = headerCenterStyle;
            e.Column.DisplayIndex = this.headerDetails[headername].ColumnIndex; //// If you have issues with the index been out of range, change the order of the get/set functions in the model class
            e.Column.CellStyle = centerStyle;                                   //// putting the get/set for any fields that are not displayed first will also help to avoid the issue
            e.Column.IsReadOnly = this.headerDetails[headername].IsReadOnly;
        }
        else
        {
            e.Column.Visibility = Visibility.Hidden;
        }
    }
