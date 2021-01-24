        public void addNewColumn(Header h, string bindcol)
        {
            DataGridColumn col = new DataGridTextColumn(){Binding=new Binding(bindcol)};
            col.Header = h;
            col.HeaderTemplate = (DataTemplate)FindResource("dgh") as DataTemplate;
            dg.Columns.Add(col);
        }
