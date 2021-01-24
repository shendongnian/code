        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "avaible")
            {
                var b = (e.Column as DataGridCheckBoxColumn).Binding as Binding;
                b.Converter = new BoolToStringConverter();
                var dgtc = new DataGridTextColumn();
                dgtc.Binding = b;
                e.Column = dgtc;
            }
        }
