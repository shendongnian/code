    DataTable invoice_table; //Global
    private void load()
    {
       invoice_table = new DataTable();
       invoice_table.Columns.Add("serial_number", typeof(int));
       invoice_table.Columns.Add("item");
       .....
    }
