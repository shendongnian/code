        ColumnDefinition col = new ColumnDefinition {Width = GridLength.Auto};
        grdSuperHeader.ColumnDefinitions.Add(col);
        var binding = new Binding("ActualWidth")
        {
            ElementName = "SampleColumn" + i.ToString()
        };
        col.SetBinding(ColumnDefinition.MaxWidthProperty, binding);
        col.SetBinding(ColumnDefinition.MinWidthProperty, binding);
