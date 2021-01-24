    DatagridAlarmConverter dac = new DatagridAlarmConverter();
    dac.HiAlarm = HighAlarm;
    dac.LoAlarm = LowAlarm;
    Style rowStyle = new Style(typeof(DataGridRow));
    rowStyle.Setters.Add(new Setter(DataGridRow.BackgroundProperty, new Binding()
            {
                Converter = dac, 
                Path = new PropertyPath("Value")
            }));
