    var tableStyle = dataGrid1.GetCurrentTableStyle();
    for (int ii = 0; ii < table.Columns.Count; ii++)
    {
        var columnStyle = tableStyle.GridColumnStyles[ii] as DataGridTextBoxColumn;
        if (columnStyle == null)
        {
            // DataGridTextBoxColumn inherits DataGridColumnStyle but in theory
            // a column might be of some other type deriving from DataGridColumnStyle.
            continue;
        }
        var columnType = table.Columns[ii].DataType;
        if (columnType != typeof(double) && columnType != typeof(float) && columnType != typeof(decimal))
        {
            // We set the format only for numeric columns.
            continue;
        }
        // 2 digits after the decimal mark.
        columnStyle.Format = "N2";
    }
    
