    var style = new Style();
            var dataTrigger = new DataTrigger
            {
                Binding = new Binding("PROPERTY_NAME"),
                Value = DESIRED_VALUE
            };
            dataTrigger.Setters.Add(new Setter
            {
                Property = Control.BackgroundProperty,
                Value = ColorConverter.ConvertFromString("Red")
            });
            style.Triggers.Add(dataTrigger);
    
    public void create_columns()
        {
           var col1 = new DataGridTextColumn();
           col1.Header = "Station";
           col1.Binding = new Binding("Station");
           
          col1.CellStyle = style;
            dataGrid.Columns.Add(col1);
