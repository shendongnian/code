        public void addNewColumn(Header h)
        {
            DataGridColumn col = new DataGridTextColumn();
            col.Header = h;
            col.HeaderTemplate = (DataTemplate)FindResource("dgh") as DataTemplate;
            dg.Columns.Add(col);
        }
