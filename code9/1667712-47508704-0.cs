    void MainDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string tooltip = null;
            switch (e.Column.Header.ToString())
            {
                case "Gauge":
                    tooltip = "Double click Gauge ID to view its details";
                    break;
            }
            if (tooltip != null)
            {
                var style = new Style(typeof(DataGridCell));
                style.Setters.Add(new Setter(ToolTipService.ToolTipProperty, tooltip));
                e.Column.CellStyle = style;
            }
        }
