      private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("stk_code"));
            table.Columns.Add(new DataColumn("stk_description"));
            table.Columns.Add(new DataColumn("quantity"));
            table.Columns.Add(new DataColumn("uom"));
            table.Columns.Add(new DataColumn("discount"));
            table.Columns.Add(new DataColumn("tax_code"));
            table.Columns.Add(new DataColumn("stk_sale_price_one"));
            return table;
        }
