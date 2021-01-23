    DataTable MyTable = null; //store the table data;
    
    //may be you means "AddData"?
    public void AddData(string stockCode, string description, string unit, string quantity, string costPrice,
              string saleprice, string taxcode)
    {
        DataTable table = MyTable
        if(table == null)
        {
            DataTable table = new DataTable();    
            table.Columns.Add(new DataColumn("stk_code"));
            table.Columns.Add(new DataColumn("stk_description"));
            table.Columns.Add(new DataColumn("quantity"));
            table.Columns.Add(new DataColumn("uom"));
            table.Columns.Add(new DataColumn("discount"));
            table.Columns.Add(new DataColumn("tax_code"));
            table.Columns.Add(new DataColumn("stk_sale_price_one"));
            MyTable = table;
        }
    
        DataRow dr = table.NewRow();
        dr[0] = stockCode;
        dr[1] = description;
        dr[2] = quantity;
        dr[3] = 0;
        dr[4] = unit;
        dr[5] = taxcode;
        dr[6] = saleprice;
        table.Rows.Add(dr);
        table.AcceptChanges();
    
        invoiceItemDataView.DataSource = table;
    }
